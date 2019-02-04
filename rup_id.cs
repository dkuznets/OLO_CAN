using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OLO_CAN
{
    public class rup_id
    {
        public const UInt32 RECONFIG_ID = (0x01 << 5);
        public const UInt32 RUP_ID = (0x03 << 5);
        public const UInt32 STATUS_REQUEST_ID = (0x04 << 5);
        public const UInt32 STATUS_RESPONCE_ID = (0x05 << 5);
        public const UInt32 ACTIV_FLASH_ID = (0x30 << 5);
        public const UInt32 WRITE_DATA_ID = (0x31 << 5);
        public const UInt32 READ_DATA_ID = (0x32 << 5);
        public const UInt32 ACK_ID = (0x33 << 5);
        public const UInt32 DATA_SEGMENT_ID = (0x34 << 5);
        public const UInt32 ERASE_ID = (0x35 << 5);
        public const UInt32 AREA_ERASE_REQUEST_ID = (0x36 << 5);
        public const UInt32 FILE_TABLE_REQUEST_ID = (0x37 << 5);
        public const UInt32 FLASH_TABLE_RESPONCE_ID = (0x38 << 5);
        public const UInt32 AREA_ERASE_RESPONCE_ID = (0x39 << 5);
        public const UInt32 FILE_TABLE_ADDRESS_ID = (0x3A << 5);
        public const UInt32 RIGHT_WING_DEV_ID = 0x11;
        public const UInt32 LEFT_WING_DEV_ID = 0x12;

        public enum IDs : uint
        {
            RECONFIG_ID = (0x01 << 5),
            RUP_ID = (0x03 << 5),
            STATUS_REQUEST_ID = (0x04 << 5),
            STATUS_RESPONCE_ID = (0x05 << 5),
            ACTIV_FLASH_ID = (0x30 << 5),
            WRITE_DATA_ID = (0x31 << 5),
            READ_DATA_ID = (0x32 << 5),
            ACK_ID = (0x33 << 5),
            DATA_SEGMENT_ID = (0x34 << 5),
            ERASE_ID = (0x35 << 5),
            AREA_ERASE_REQUEST_ID = (0x36 << 5),
            FILE_TABLE_REQUEST_ID = (0x37 << 5),
            FLASH_TABLE_RESPONCE_ID = (0x38 << 5),
            AREA_ERASE_RESPONCE_ID = (0x39 << 5),
            FILE_TABLE_ADDRESS_ID = (0x3A << 5),
            RIGHT_WING_DEV_ID = 0x11,
            LEFT_WING_DEV_ID = 0x12
        };
        public enum Receipt { RUN, READY, ERROR, COMPLETE };
        public enum Mode { WORK, ECONTROL, CONTROL, PROGRAM };
        public enum Comm
        {
            RUP_ID = 0x03,
            RECONFIG_ID = 0x01,
            ACTIV_FLASH_ID = 0x30,
            WRITE_DATA_ID = 0x31,
            READ_DATA_ID = 0x32,
            ERASE_ID = 0x35
        };

    }
}
