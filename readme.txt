Wiimote Remote Control
v1.0.1.0
David Schraitle - putting it all together
Johnny Chung Lee - wiimote connection and usage (http://www.cs.cmu.edu/~johnny/projects/wii/)
Brian Peek - simply amazing wiimote library without which nothing would be possible (http://blogs.msdn.com/coding4fun/archive/2007/03/14/1879033.aspx)

Description:-----------------------------------------------
This handy little program turns your Wiimote into a fully customizeable tool for you to use along with your computer. 


Usage:-----------------------------------------------------
Connect your wiimote to your computer via bluetooth, an guide to doing so can be found here: http://www.wiili.org/index.php/How_To:_BlueSoleil  or through a quick google search. Once the wiimote is connected, you can use the program to map the buttons of the wiimote to whatever you find in the drop down lists associated with each button.

Custom:
There is a custom field on the bottom left of the window. This corresponds to the Custom item which you can select in the drop down menus. This area lets you type in what you want, and then be able to replicate it on one of the wiimote buttons. The custom field uses a SendKeys function, which enables you to send special buttons, as well as characters, and the usage can be found here: http://msdn.microsoft.com/en-us/library/system.windows.forms.sendkeys(VS.71).aspx  Basically the most useful keys to know are Control(^), Shift(+), and Alt(%) To use the custom field, type what you want into it, them choose the "Custom" item in a dropdown menu. The menu text will change to that of the custom field, and you can go about using it. Once you change that dropdown menu, the custom text will be erased and a new string will go into the item. You can have as many custom fields as you want, as long as you change the text between each time you click the drop down menus.

Saving/Loading:
The program uses the registry to store the state of the dropdown menus and custom key data. In order to save the dropdown settings, click File->Save on the menu, and choose a location for the file. To load a file, just click File->Load from the menu, and the settings will be applied.

Connect:
If you happen to connect your wiimote after the program loads, you can click the "Connect" button at the bottom of the window to connect your wiimote to the program. This doesn't always work, especially when the wiimote isn't the first device to be sync'd to the system, but it's worth a try anyway.


Bugs:------------------------------------------------------
When you turn the wiimote off while the program is still running, an error occurs, so try not to do that.

sometimes wiimotes don't connect if they're not the first thing connected to the bluetooth driver.

not all combinations of customizeable keys have been tested, so there may be complications if you find the right sequence