# FormsFileWatcher
This is a Oracle Forms Proof-of-Concept demo for exchanging data files in a watched directory:
- producing and sending (write file)
- receiving and consuming (read file) .

## Motivation

Interactions of Oracle Forms with other runtimes or virtual machines are sometimes difficult on the local front-end side. <br/>A practical and simple solution is realized with exchanging data files in temporary watched directories. <br/>  Forms can send or receive files in watched directories, so there is a simple *`One Line Data Format`* for interacting used: *`Action|Parameter1|Parameter2`* .. .
  You can apply to parse this simple format with the *`d2dlkstr2.pll`* library, modified from original d2dlkstr.pll.

This Forms solution includes the *`FormsFileWatcherPJC`* : https://github.com/Fxztam/FormsFileWatcherPJC .

<img src="http://www.fmatz.com/FINAL-watch-2.gif">

## Running

>- Ping-pong Loop
>After signing the FormsFileWatcherPJC.jar with a certificate from a Trusted Certificate Authority, deploying this certificated JAR file >and re-start the Forms Weblogic Server you can test:

  1. *"Start"*
  2. *"Loop"*  ( ping-pong testing loop)
  3. *"Stop"* .

Enjoy it.


 
