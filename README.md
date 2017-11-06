# FormsFileWatcher

This demo is a proof of concept for waiting of file changes (create, update, delete) in a watched directory:
- producing and sending (write files)
- receiving and consuming (read files)
with Oracle Forms. 

## Motivation

The interaction of Oracle Forms with other runtimes or virtual machines at the local front-end client side is sometimes difficult. A practical and simple solution is realized with exchanging data files in temporary watched directories here: Forms can send or receive files in defined watched directories. There is a simple data format: Action|Parameter1|Parameter2 .. so you can use the well known *`d2kstr.pll`* for parsing it.

This Forms solution based on the *`FormsFileWatcherPJC`* : https://github.com/Fxztam/FormsFileWatcherPJC 

>**Note:** 
>Use the directories that are applied to the *`FormsFileWatcher Demo`* : https://github.com/Fxztam/FormsFileWatcher

## Example
- Start Forms File Watcher Service, e.g. in:
- 
*`WHEN-NEW-FORMS-INSTANCE`* - Trigger : 

```sql
   BEGIN
     Set_Custom_Property('BLK_BEANS.BEAN_FWATCHER_SEND',    1, 'SetStartServer', 'forms');
     Set_Custom_Property('BLK_BEANS.BEAN_FWATCHER_RECEIVE', 1, 'SetStartServer', 'forms2');  
   EXCEPTION WHEN OTHERS THEN
	  prc_show('$$$ EXCEPTION: '||sqlerrm);
   END;
```   
```sql
   BEGIN
	 -- Start LOOP : up & running . --
	....

     Set_Custom_Property('BLK_BEANS.BEAN_FWATCHER_RECEIVE',  
       						1, 
       						'SendAction2Forms', 
       						'forms2|Action2Forms|Para1|Para2|Para3'
       					 );
   
EXCEPTION WHEN OTHERS THEN
	prc_show('$$$ EXCEPTION: '||sqlerrm);
END W_B_P_BT_LOOP;
```   
```sql
   BEGIN 
     Set_Custom_Property('BLK_BEANS.BEAN_FWATCHER_SEND',     1, 'SetKillServer', '');
     Set_Custom_Property('BLK_BEANS.BEAN_FWATCHER_RECEIVE',  1, 'SetKillServer', '');
   
   EXCEPTION WHEN OTHERS THEN
	 prc_show('$$$ EXCEPTION: '||sqlerrm);
   END;
```   

- Sending files for watching e.g. in C# - only one statement to sending a watcher event to Oracle Forms:

```Csharp
using System;

namespace FileWrite
{
    class Program
    {
        static void Main(string[] args)
        {
            // --- sending a action from C# to Oracle Forms       
            string ACTION2FORMS = "C#2FORMS|Hello OracleForms|P2";
            System.IO.File.WriteAllText(@"C:\Users\fmatz\AppData\Local\Temp\formswatch\forms\Action2Forms.watch", ACTION2FORMS);

            // .. consuming the action ..
            System.Threading.Thread.Sleep(2000);

            // --- sending 'End of Watching..' from C# to Oracle Forms  
            string[] EOWATCHING = { "Watcher finished from C# ", DateTime.Now.ToString(), "FINISHED." };
            System.IO.File.WriteAllLines(@"C:\Users\fmatz\AppData\Local\Temp\formswatch\forms\EOwatchService.watch", EOWATCHING);

            // console end.
            Console.WriteLine("\n--- EO Watching. <enter> ---");
            Console.ReadKey();
        }
    }
}
```

## Getting Started

### Architecture 

<img src="http://www.fmatz.com/Flow-2.jpg">

### Prerequisites

- Tested with Oracle Forms 12.2.1.2

- Start the *`FormsFileWatcher Demo`* : https://github.com/Fxztam/FormsFileWatcher or using a file editor for modifying

>**Note:**
>You can also simulate file changes by editing in the watcher directory defined in the *`IronWatcherForms.py`*


### Installing

Following steps for installation of the *`IronWatcherForms.py`* and *`IronWatcherForms2.py`* files:

1. Installing IronPython 2.7.7 : http://ironpython.net/

2. Verify the IronPython installation
    ```
    DOS> ipy
    IronPython 2.7.7 (2.7.7.0) on .NET 4.0.30319.42000 (32-bit)
    Type "help", "copyright", "credits" or "license" for more information.
    >>>
    ```

2. Create a working directory e.g.  *..\Work-FileWatcher*

3. Copy the files *IronWatcherForms.py* and *`start_IronWatcher.cmd`* to the *`Work-FileWatcher`* directory

4. Modify *`IronWatcherForms.py`* - adapting the File Watcher directory

>**Note:**
>The FormsFileWatcher Demo is using the Windows user temp path as directory root, e.g. :
>*`C:\Users\fmatz\AppData\Local\Temp\formswatch\forms`* for FormsFileWatcher Demo (internal default here).

5. Modify *`start_IronWatcher.cmd`* - adapting the *`ipy.exe`* - command line


## Running the tests

Change to the Work-FileWatcher directory and start the IronPython FileWatcher
```
DOS> start_IronWatcher.cmd
```
and this shows the running demo:

<img src="http://www.fmatz.com/FormsWatcher.gif">


## Contributing

This PoC demo was adapted from : http://www.ironpython.info/index.php?title=Watching_the_FileSystem

## Versioning

Proof of Concept version

## Author

Friedhold Matz, November 2017

## License

Free License
