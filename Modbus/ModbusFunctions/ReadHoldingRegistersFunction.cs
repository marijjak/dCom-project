using Common;
using Modbus.FunctionParameters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

namespace Modbus.ModbusFunctions
{
    /// <summary>
    /// Class containing logic for parsing and packing modbus read holding registers functions/requests.
    /// </summary>
    public class ReadHoldingRegistersFunction : ModbusFunction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReadHoldingRegistersFunction"/> class.
        /// </summary>
        /// <param name="commandParameters">The modbus command parameters.</param>
        public ReadHoldingRegistersFunction(ModbusCommandParameters commandParameters) : base(commandParameters)
        {
            CheckArguments(MethodBase.GetCurrentMethod(), typeof(ModbusReadCommandParameters));
        }

        /// <inheritdoc />
        public override byte[] PackRequest()
        {
            ModbusReadCommandParameters p =
    (ModbusReadCommandParameters)CommandParameters;

            byte[] request = new byte[12];

            request[0] = (byte)(p.TransactionId >> 8);
            request[1] = (byte)(p.TransactionId);
            request[2] = (byte)(p.ProtocolId >> 8);
            request[3] = (byte)(p.ProtocolId);
            request[4] = (byte)(p.Length >> 8);
            request[5] = (byte)(p.Length);
            request[6] = p.UnitId;
            request[7] = p.FunctionCode;
            request[8] = (byte)(p.StartAddress >> 8);
            request[9] = (byte)(p.StartAddress);
            request[10] = (byte)(p.Quantity >> 8);
            request[11] = (byte)(p.Quantity);

            return request;
        }

        /// <inheritdoc />
        public override Dictionary<Tuple<PointType, ushort>, ushort> ParseResponse(byte[] response)
        {
            ModbusReadCommandParameters p =
    (ModbusReadCommandParameters)CommandParameters;

            var result = new Dictionary<Tuple<PointType, ushort>, ushort>();

            if (response[7] == p.FunctionCode + 0x80)
            {
                HandeException(response[8]);
                return result;
            }

            for (int i = 0; i < p.Quantity; i++)
            {
                int byteIndex = 9 + (i * 2);
                ushort value = (ushort)((response[byteIndex] << 8) | response[byteIndex + 1]);
                ushort address = (ushort)(p.StartAddress + i);
                result.Add(new Tuple<PointType, ushort>(PointType.ANALOG_OUTPUT, address), value);
            }

            return result;
        }
    }
}