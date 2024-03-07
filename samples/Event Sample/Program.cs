//-----------------------------------------------------------------------------
// FACTORY I/O (SDK)
//
// Copyright (C) Real Games. All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Threading;

namespace EngineIO.Samples
{
    using System.Globalization;

    internal static class Program
    {
        //In this sample we are showing how to use the InputsNameChanged, InputsValueChange, OutputsNameChanged and OutputsValueChange events.
        //Add, change and remove Tags in Factory I/O to get notified about its memories changes (no Saved Scene needed).
        static void Main()
        {
            //Registering on the events
            MemoryMap.Instance.InputsNameChanged += Instance_NameChanged;
            MemoryMap.Instance.InputsValueChanged += Instance_ValueChanged;
            MemoryMap.Instance.OutputsNameChanged += Instance_NameChanged;
            MemoryMap.Instance.OutputsValueChanged += Instance_ValueChanged;

            Console.WriteLine("Press any key to exit...");

            //Calling the Update method will fire events if any memory value or name changed.
            //When a Tag is created in Factory I/O a name is given to its memory, firing the name changed event, and when a tag's value is changed, it is fired the value changed event.
            //In this case we are updating the MemoryMap each 16 milliseconds (the typical update rate of Factory I/O).
            while (!Console.KeyAvailable)
            {
                MemoryMap.Instance.Update();

                Thread.Sleep(16);
            }  

            //When we no longer need the MemoryMap we should call the Dispose method to release all the allocated resources.
            MemoryMap.Instance.Dispose();
        }

        static void Instance_NameChanged(MemoryMap sender, MemoriesChangedEventArgs value)
        {
            //Display any changed MemoryBit
            foreach (var mem in value.MemoriesBit)
            {
                Console.WriteLine(mem.HasName
                    ? $"{mem.MemoryType.ToString()} Bit({mem.Address}) name changed to: {mem.Name}"
                    : $"{mem.MemoryType.ToString()} Bit({mem.Address}) name cleared");
            }

            //Display any changed MemoryFloat
            foreach (var mem in value.MemoriesFloat)
            {
                Console.WriteLine(mem.HasName
                    ? $"{mem.MemoryType.ToString()} Float({mem.Address}) name changed to: {mem.Name}"
                    : $"{mem.MemoryType.ToString()} Float({mem.Address}) name cleared");
            }

            //Display any changed MemoryInt
            foreach (var mem in value.MemoriesInt)
            {
                Console.WriteLine(mem.HasName
                    ? $"{mem.MemoryType.ToString()} Int({mem.Address}) name changed to: {mem.Name}"
                    : $"{mem.MemoryType.ToString()} Int({mem.Address}) name cleared");
            }
        }

        static void Instance_ValueChanged(MemoryMap sender, MemoriesChangedEventArgs value)
        {
            //Display any changed MemoryBit
            foreach (var mem in value.MemoriesBit)
            {
                Console.WriteLine(
                    $"{mem.MemoryType.ToString()} Bit{mem.Address} value changed to: {mem.Value.ToString()}");
            }

            //Display any changed MemoryFLoat
            foreach (var mem in value.MemoriesFloat)
            {
                Console.WriteLine(
                    $"{mem.MemoryType.ToString()} Float{mem.Address} value changed to: {mem.Value.ToString(CultureInfo.CurrentCulture)}");
            }

            //Display any changed MemoryInt
            foreach (var mem in value.MemoriesInt)
            {
                Console.WriteLine(
                    $"{mem.MemoryType.ToString()} Int{mem.Address} value changed to: {mem.Value.ToString()}");
            }
        }
    }
}
