//-----------------------------------------------------------------------------
// FACTORY I/O (SDK)
//
// Copyright (C) Real Games. All rights reserved.
//-----------------------------------------------------------------------------

using EngineIO;

namespace Controllers
{
    public class FromAToB : Controller
    {
        MemoryBit _conveyor = MemoryMap.Instance.GetBit("Conveyor", MemoryType.Output);

        MemoryBit _sensor = MemoryMap.Instance.GetBit("Sensor", MemoryType.Input);

        public FromAToB()
        {
            _conveyor.Value = false;
        }

        public override void Execute(int elapsedMilliseconds)
        {
            _conveyor.Value = _sensor.Value;
        }
    }
}
