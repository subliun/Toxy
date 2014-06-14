Toxy [![Build Status](http://jenkins.impy.me/job/Toxy/badge/icon)](http://jenkins.impy.me/job/Toxy/)
====

Metro-style Tox client for Windows. ([Tox](https://github.com/irungentoo/ProjectTox-Core "ProjectTox GitHub repo") is a free (as in freedom) Skype replacement.)

At this point, this project isn't feature-complete and is not ready for an official release.
Some features may be missing or partially broken. Updates will arrive in time.

Feel free to contribute.

### Features

* Standard features like:
  - Nickname customization
  - Status customization
  - Friendlist
  - One to one conversations
  - Friendrequest listing
* Audio calls
* Group chats
* File transfers
* Typing detection
* Nospam value customization
* DNS discovery (tox1 and tox3)

### Screenshots

![Main Window](http://impy.me/i/1d83d3.png)

Binaries
===
A pre-compiled version of Toxy can be found [here](http://jenkins.impy.me/job/Toxy/lastSuccessfulBuild/artifact/toxy.zip "Toxy Binaries"). This includes all of the dependencies.

Things you'll need to compile
===

* Libraries of the [MetroFramework](https://github.com/viperneo/winforms-modernui "MetroFramework GitHub repo")
* The [SharpTox library](https://github.com/Impyy/SharpTox "SharpTox GitHub repo") and its dependencies.

All other dependencies can be found in the packages.config file and should be downloaded by Visual Studio automatically
