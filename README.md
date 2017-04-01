### Project Description

Visual SourceSafe to Subversion allows VSS databases to be imported into new or existing SVN repositories.

You can use a user friendly GUI to configure the migration, or use the command line.

Using VSS2SVN you can select which projects to include, allowing a partial import of a database. VSS2SVN can work with new repositories or existing repositories, making it easy to merge multiple VSS databases into a single SVN repository. The tool can also handle limited SourceSafe database corruption if versions of a given file cannot be accessed.

This tool came about due to the limitations of a [third party tool](http://www.poweradmin.com/SOURCECODE/VSSMIGRATE.ASPX) I was using to migrate a database. While this worked after a fashion (my initial experiences are [detailed here](http://cyotek.com/blog/migrating-from-visual-sourcesafe-to-subversion)) it did require a number of modifications. Despite these it still didn't serve the purposed I needed it for (mainly the ability to import multiple VSS databases with the same project structures into a single repository) and so this tool was created, reusing much of the the original code.

Many thanks to [Damir Valiulin](http://www.codeplex.com/site/users/view/DamirValiulin) who has updated the project to include a bunch of extra features (such as no longer needing physical file access to the repository in order to change revision props) and some welcome bug fixes.

### Usage

Both a command line and GUI version is provided, both of which call the same back end class library which could be used independently of either front end. See the documentation topic for more information.

In order to use this tool, Visual SourceSafe must be installed in order to access the SourceSafe API library. I recommend you use Visual SourceSafe 2005 with the latest bug fix roll up. Some code changes may be required if using Visual SoourceSafe 6.0d.

If you download the source code, then you will need the latest SharpSVN package.

You **must** have a pre-revision property change hook on your repository. If this hook is not present, revision information cannot be updated and your migration will halt.

**Important: I used this tool to create a brand new repository, import a VSS database into it, then import a second VSS database. This tool has not been extensively tested, please ensure you have backups of your repositories and files before using this tool.**

### Screenshots

The screenshots below show the GUI in use, and when it has completed.

<img src="https://www.cyotek.com/files/vsstosvn/vsstosvn1.png" alt="During the conversion of a database containing some corruption" width="872" height="719" />

<img src="https://www.cyotek.com/files/vsstosvn/vsstosvn2.png" alt="After a successful migration" width="872" height="719" />
