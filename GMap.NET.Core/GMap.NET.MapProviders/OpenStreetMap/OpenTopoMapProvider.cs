using System;

namespace GMap.NET.MapProviders
{
   public class OpenTopoMapProvider : OpenStreetMapProviderBase
   {
      public static readonly OpenTopoMapProvider Instance;

      OpenTopoMapProvider()
      {
         RefererUrl = "http://www.opencyclemap.org/";
      }

      static OpenTopoMapProvider()
      {
         Instance = new OpenTopoMapProvider();
      }

      #region GMapProvider Members

      readonly Guid id = new Guid("9E82F8CA-5687-4886-8571-4A53B92AE47D");
      public override Guid Id
      {
         get
         {
            return id;
         }
      }

      readonly string name = "OpenTopoMap";
      public override string Name
      {
         get
         {
            return name;
         }
      }

      GMapProvider[] overlays;
      public override GMapProvider[] Overlays
      {
         get
         {
            if (overlays == null)
            {
               overlays = new GMapProvider[] { this };
            }
            return overlays;
         }
      }

      public override PureImage GetTileImage(GPoint pos, int zoom)
      {
         string url = MakeTileImageUrl(pos, zoom, string.Empty);

         return GetTileImageUsingHttp(url);
      }

      #endregion

      string MakeTileImageUrl(GPoint pos, int zoom, string language)
      {
         char letter = ServerLetters[GMapProvider.GetServerNum(pos, 3)];
         return string.Format(UrlFormat, letter, zoom, pos.X, pos.Y);
      }

      static readonly string UrlFormat = "https://tile-{0}.opentopomap.ru/{1}/{2}/{3}.png";
   }
}
