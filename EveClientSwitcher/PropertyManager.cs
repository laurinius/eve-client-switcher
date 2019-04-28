using System;
using System.Windows.Forms;
using System.IO;

namespace EveClientSwitcher
{
    class PropertyManager
    {
        public struct PROPS
        {
            public int switchModifier;
            public int minimizeModifier;
            public Keys switchKey;
            public Keys minimizeKey;
        }

        private const string propsFile = "ecs.dat";

        public void SaveProps(PROPS props)
        {
            string propsString = "";
            propsString += props.minimizeModifier + ",";
            propsString += (int)props.minimizeKey + ",";
            propsString += props.switchModifier + ",";
            propsString += (int)props.switchKey;
            File.WriteAllText(propsFile, propsString);
        }

        public PROPS ReadProps()
        {
            PROPS props = new PROPS();
            if (!File.Exists(propsFile))
            {
                props.minimizeModifier = 5;
                props.minimizeKey = Keys.X;
                props.switchModifier = 5;
                props.switchKey = Keys.S;
            }
            else
            {
                string[] propsArray = File.ReadAllText(propsFile).Split(',');
                props.minimizeModifier = Convert.ToInt16(propsArray[0]);
                props.minimizeKey = (Keys)Convert.ToInt16(propsArray[1]);
                props.switchModifier = Convert.ToInt16(propsArray[2]);
                props.switchKey = (Keys)Convert.ToInt16(propsArray[3]);
            }

            return props;
        }

        public PROPS CopyProps(PROPS props)
        {
            return new PROPS()
            {
                minimizeModifier = props.minimizeModifier,
                minimizeKey = props.minimizeKey,
                switchModifier = props.switchModifier,
                switchKey = props.switchKey
            };
        }
    }
}
