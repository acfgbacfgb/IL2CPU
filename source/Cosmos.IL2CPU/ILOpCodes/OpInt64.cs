﻿using System;
using System.Reflection;

namespace Cosmos.IL2CPU.ILOpCodes
{
  public class OpInt64 : ILOpCode
  {
    public ulong Value { get; }

    public OpInt64(Code aOpCode, int aPos, int aNextPos, ulong aValue, _ExceptionRegionInfo aCurrentExceptionRegion)
      : base(aOpCode, aPos, aNextPos, aCurrentExceptionRegion)
    {
      Value = aValue;
    }

    public override int GetNumberOfStackPops(MethodBase aMethod)
    {
      switch (OpCode)
      {
        case Code.Ldc_I8:
          return 0;
        default:
          throw new NotImplementedException("OpCode '" + OpCode + "' not implemented!");
      }
    }

    public override int GetNumberOfStackPushes(MethodBase aMethod)
    {
      switch (OpCode)
      {
        case Code.Ldc_I8:
          return 1;
        default:
          throw new NotImplementedException("OpCode '" + OpCode + "' not implemented!");
      }
    }

    protected override void DoInitStackAnalysis(MethodBase aMethod)
    {
      base.DoInitStackAnalysis(aMethod);

      switch (OpCode)
      {
        case Code.Ldc_I8:
          StackPushTypes[0] = typeof (long);
          return;
        default:
          break;
      }
    }
  }
}
