# FormsFileWatcher => coming soon.
This is a proof-of-concept Oracle Forms demo for exchanging data files in a watched directory:
- producing and sending (write file)
- receiving and consuming (read file) .

## Motivation

Interactions of Oracle Forms with other runtimes or virtual machines is sometimes difficult on the local front-end side. A practical and simple solution is realized here with exchanging data files in temporary watched directories. Forms can send or receive files in defined watched directories, so there is a simple *`one line data format`* used: *`Action|Parameter1|Parameter2`* .. .
You can apply to parse this simple format with the well known *`d2dlkstr.pll`* library.

This Forms solution includes the *`FormsFileWatcherPJC`* : https://github.com/Fxztam/FormsFileWatcherPJC .

