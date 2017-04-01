### Getting Started

**Important: I used this tool to create a brand new repository, import a VSS database into it, then import a second VSS database. This tool has not been extensively tested, please ensure you have backups of your repositories and files before using this tool.**

You **must** have a pre-revision property change hook on your repository. If this hook is not present, revision information cannot be updated and your migration will halt.

### Using the GUI

1.  Specify the SourceSafe database to import. You can leave this blank and the default registered database will be used.
2.  Select the SourceSafe projects to import using the project browser. You can import multiple projects at once.
3.  <span style="font-size: 10pt;">Specify the URI of your subversion repository, for example http://mysvnserver/trunk. You can also specify the credentials to connect to this repository if required.</span>
4.  Optionally, specify an additional root project name. This will be added to the URI as required.
5.  <span style="font-size: 10pt;">Click **Preview** in order to display the list of projects and files which will be exported from SourceSafe. The preview will also warn of any files which are checked out or pinned files.</span>
6.  Once you are happy everything is configured, click **Migrate** to begin. Please note this can take a significant amount of time - in my case, it took 40 hours to migrate two SourceSafe databases.

*NOTE: As of version 2.0, there are no longer options to exclude sub projects or strip VSS bindings. Sub projects are now always included and VSS bindings are always stripped.*

### Advanced Options

Clicking the **Advanced** button will display a dialog allowing all configurable properties to be specified - useful as I forgot to add SVN credentials to the main UI.

You can also specify the root directory where the temporary working copy is created. If this not specified, the default will be a subfolder named *\_migrate* in your system's temporary files folder. Please note that this directory and all contents will be erased by the migration. Depending on the path depth of the databases you are importing, it's probably a good idea to configure a custom folder in your drive's root.

Sometimes SVN commits can fail - by default it will retry twice before abandoning the commit and moving onto the next one. You can configure this value.

### Command Parameters

The following command parameters can be used by both the GUI and command line clients

-   **(filename)** - a configuration file to load
-   **vssdb** - the path of a SourceSafe database (optional)
-   **vssuser** - SourceSafe login username (optional)
-   **vsspassword** - SourceSafe login password (optional)
-   **svnrepo** - URI of a Subversion repository
-   **svnuser** - SVN login username (optional)
-   **svnpassword** - SVN login password (optional)
-   <span style="font-size: 10pt;">**svnproject** - Root SVN project (optional)</span>
-   **nosub** <span style="font-size: 10pt;">- Place VSS projects directly under the root without including the VSS project name. Only valid when migrating a single VSS project.</span>
-   <span style="font-size: 10pt;">**temppath** - Path used for working copies</span>
-   **preview** - Performs a preview. No changes are made to the SVN repository (command line client only)

For the command line client, if the **/preview** argument is not specify the migration is performed.

### Basic Command Line Client Example

This example command will migrate the entire contents of the VSS database named "test1" into the "test" VSN repository.

    vsssvn.exe /vssdb=C:\SourceSafe\test1 /vssproject=$/ /svnrepo=https://HADES:8443/svn/test2/trunk/ /temppath=C:\temp\_migrate

### Things to improve

-   Add options for SVN credentials to the main UI
-   Currently the import checks out the entire SVN repository prior to a commit. It would be better if it was clever enough only to checkout projects which would be affected by the import.
-   When importing a lot of commits to the same file, the tool will repeatedly try to add the file to SVN even though it is already present. Better detection would help here.
-   If SourceSafe cannot get a particular version of a file, it is skipped. A record of all skipped files is kept, but I forgot to add add a way of displaying this information in the front end. In addition, while the tool handles this kind of database corruption, it may not handle other types.

