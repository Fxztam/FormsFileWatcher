# FormsFileWatcher
This is a Oracle Forms Proof-of-Concept demo for exchanging data files in a watched directory:
- producing and sending (write file)
- receiving and consuming (read file) .

## Motivation

Interactions of Oracle Forms with other runtimes or virtual machines are sometimes difficult on the local front-end side. <br/>A practical and simple solution is realized with exchanging data files in temporary watched directories. <br/>  Forms can send or receive files in watched directories, so there is a simple *`One Line Data Format`* for interacting used: *`Action|Parameter1|Parameter2`* .. .
  You can apply to parse this simple format with the *`d2dlkstr2.pll`* library, modified from original d2dlkstr.pll.

This Forms solution includes the *`FormsFileWatcherPJC`* : https://github.com/Fxztam/FormsFileWatcherPJC .

## Examples

- Ping-pong testing loop:
<img src="http://www.fmatz.com/FINAL-watch-2.gif">

- C# sending demo *"FileWatcherSend.cs"* 
<img src="http://www.fmatz.com/CsharpToForms.jpg">

## Modul chk_fwatcherself.fmb

- Forms module view

<img src="http://www.fmatz.com/chk_fwatchself.png">

- Sequence diagram 

<img src="http://www.fmatz.com/FLOW-final.png">

## Modul FileWatcherSend.cs

This C# module https://github.com/Fxztam/FormsFileWatcher/blob/master/FileWatcherSend.cs sends *`Action2Forms`* and *`EOwatchSercice`* :

<img src="http://www.fmatz.com/Csharp-Action.png">
<img src="http://www.fmatz.com/csharp-finished.png">

## Running

This Oracle Forms module was tested on:
- Windows 10
- IE 11 
- Java 8_151 32 Bit (11.151.2.12 x86)
- Oracle Forms 12.2.1.2.0 .

After signing the FormsFileWatcherPJC.jar with a certificate from a Trusted Certificate Authority, deploying this certificated JAR file and re-starting the Forms Weblogic Server you can test:

- Ping-pong testing loop:

  1. *"Start"*
  2. *"Loop"*  
  3. *"Stop"* 

- C# sending demo:

   1. *"Start"*
   2. *"Run FileWatcherSend.cs"*
   3. *"Stop"* .

## Status

Proof of Concept

Enjoy it.


 
