using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Text;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WindowedWerewolf
{
    // TODO This class is rather useles - I finally figured out how to load font from the resources but it ain't pretty
    // I'll figure this out some time later
    
    class ResourceFontFetcher
    {
        private PrivateFontCollection pfc;
        Dictionary<byte[], int> fontMap;

        public ResourceFontFetcher()
        {
            this.pfc = new PrivateFontCollection();
            this.fontMap = new Dictionary<byte[], int>();
        }

        public System.Drawing.FontFamily GetFontFromResource(byte[] fontResource)
        {
            var assembly = Assembly.GetExecutingAssembly();

            foreach (var resourceName in assembly.GetManifestResourceNames()) {
                    Debug.WriteLine(resourceName);
            }

            IntPtr ptr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontResource.Length);
            //copy the font data byte array to memory
            System.Runtime.InteropServices.Marshal.Copy(fontResource, 0, ptr, fontResource.Length);
            //Add the font to the private font collection
            pfc.AddMemoryFont(ptr, fontResource.Length);

            //
            return pfc.Families[0];
        }
    }
}
