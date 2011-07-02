using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SourceSafeTypeLib;

namespace Cyotek.SourceSafeSvnMigration
{
  public partial class SelectVssProjectsDialog : BaseDialog
  {
    VSSDatabase _database;

    public SelectVssProjectsDialog()
    {
      InitializeComponent();
    }

    public VssMigration MigrationSettings { get; set; }

    public SelectVssProjectsDialog(VssMigration migrationSettings)
      : this()
    {
      if (migrationSettings == null)
        throw new ArgumentNullException("migrationSettings");

      this.MigrationSettings = migrationSettings;

      _database = VssUtilities.OpenDatabase(migrationSettings.VssConnectionSettings);
      this.AddProjectNode(null, _database.get_VSSItem("$/"));
    }

    private void AddProjectNode(TreeNode parent, VSSItem project)
    {
      TreeNode node;

      if (project == null)
        throw new ArgumentNullException("project");

      if (project.Type != (int)VSSItemType.VSSITEM_PROJECT)
        throw new ArgumentException("project");

      node = new TreeNode()
      {
        Text = project.Spec != "$/" ? project.Name : project.Spec,
        Name = project.Spec,
        Checked = this.MigrationSettings.SourceSafeProjects.Contains(project.Spec),
        ImageKey = "project"
      };

      if (VssUtilities.DoesProjectContainSubProjects(project))
        node.Nodes.Add(new TreeNode("##autoload##"));

      if (parent == null)
        projectsTreeView.Nodes.Add(node);
      else
        parent.Nodes.Add(node);
    }



    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      if (_database != null)
        _database.Close();

      base.OnFormClosing(e);
    }

    private void projectsTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
      if (e.Node != null && e.Node.Nodes.Count == 1 && e.Node.FirstNode.Text == "##autoload##")
      {
        VSSItem project;

        e.Node.FirstNode.Remove();

        project = _database.get_VSSItem(e.Node.Name);
        foreach (VSSItem childItem in project.Items)
        {
          if (childItem.Type == (int)VSSItemType.VSSITEM_PROJECT)
            this.AddProjectNode(e.Node, childItem);
        }

        e.Cancel = e.Node.Nodes.Count == 0;
      }
    }

    private void okButton_Click(object sender, EventArgs e)
    {
      // remove anything present but unchecked
      for (int i = 0; i > this.MigrationSettings.SourceSafeProjects.Count; i--)
      {
        string spec;
        TreeNode[] nodes;

        spec = this.MigrationSettings.SourceSafeProjects[i - 1];
        nodes = projectsTreeView.Nodes.Find(spec, true);

        if (nodes != null && nodes.Length != 0 && !nodes[0].Checked)
          this.MigrationSettings.SourceSafeProjects.RemoveAt(i - 1);
      }

      // now add anything that's checked
      foreach (TreeNode node in projectsTreeView.Nodes)
        this.AddCheckedProjects(node);

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    private void AddCheckedProjects(TreeNode node)
    {
      if (node.Checked && !this.MigrationSettings.SourceSafeProjects.Contains(node.Name))
        this.MigrationSettings.SourceSafeProjects.Add(node.Name);

      foreach (TreeNode childNode in node.Nodes)
        this.AddCheckedProjects(childNode);
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close();
    }
  }
}
