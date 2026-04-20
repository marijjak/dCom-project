using Common;
using Modbus.FunctionParameters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

namespace Modbus.ModbusFunctions
{
    /// <summary>
    /// Class containing logic for parsing and packing modbus write single register functions/requests.
    /// </summary>
    public class WriteSingleRegisterFunction : ModbusFunction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WriteSingleRegisterFunction"/> class.
        /// </summary>
        /// <param name="commandParameters">The modbus command parameters.</param>
        public WriteSingleRegisterFunction(ModbusCommandParameters commandParameters) : base(commandParameters)
        {
            CheckArguments(MethodBase.GetCurrentMethod(), typeof(ModbusWriteCommandParameters));
        }

        /// <inheritdoc />
        public override byte[] PackRequest()
        {
            ModbusWriteCommandParameters p =
     (ModbusWriteCommandParameters)CommandParameters;

            byte[] request = new byte[12];

            request[0] = (byte)(p.TransactionId >> 8);
            request[1] = (byte)(p.TransactionId);
            request[2] = (byte)(p.ProtocolId >> 8);
            request[3] = (byte)(p.ProtocolId);
            request[4] = (byte)(p.Length >> 8);
            request[5] = (byte)(p.Length);
            request[6] = p.UnitId;
            request[7] = p.FunctionCode;
            request[8] = (byte)(p.OutputAddress >> 8);
            request[9] = (byte)(p.OutputAddress);
            request[10] = (byte)(p.Value >> 8);
            request[11] = (byte)(p.Value);

            return request;
        }

        /// <inheritdoc />
        public override Dictionary<Tuple<PointType, ushort>, ushort> ParseResponse(byte[] response)
        {
            ModbusWriteCommandParameters p =
    (ModbusWriteCommandParameters)CommandParameters;

            var result = new Dictionary<Tuple<PointType, ushort>, ushort>();

            if (response[7] == p.FunctionCode + 0x80)
            {
                HandeException(response[8]);
                return result;
            }

            ushort address = (ushort)((response[8] << 8) | response[9]);
            ushort value = (ushort)((response[10] << 8) | response[11]);
            result.Add(new Tuple<PointType, ushort>(PointType.ANALOG_OUTPUT, address), value);

            return result;
        }
    }
}