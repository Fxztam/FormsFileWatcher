# FormsFileWatcher => coming soon.
This is a proof-of-concept demo for exchanging data files in a watched directory:
- producing and sending (write file)
- receiving and consuming (read file)
with Oracle Forms. 

## Motivation

Interactions of Oracle Forms with other runtimes or virtual machines is sometimes very difficult on the local front-end side. A practical and simple solution is realized here with exchanging data files in temporary watched directories: Forms can send or receive files in defined watched directories. <br/>There is a simple *`one line data format`* used: 
*`Action|Parameter1|Parameter2`* .. 
so you can apply to parse it with the well known *`d2dlkstr.pll`*.

This Forms solution includes the *`FormsFileWatcherPJC`* : https://github.com/Fxztam/FormsFileWatcherPJC 

