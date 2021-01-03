using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Xml.Schema;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly List<Shirt> _shirts;

        public SearchEngine(List<Shirt> shirts)
        {
            _shirts = shirts ?? throw new ArgumentNullException(nameof(shirts));

            // TODO: data preparation and initialisation of additional data structures to improve performance goes here.

        }


        public SearchResults Search(SearchOptions options)
        {
            //  var shirts = _shirts.AsEnumerable();

            //var colorCounts = from shirt in shirts
            //    where options.Colors.Contains(shirt.Color) 
            //    group shirt by shirt.Color
            //    into colorGroup
            //    select new ColorCount()
            //    {
            //        Color = colorGroup.Key,
            //        Count = colorGroup.Count()
            //    };

            //var sizeCounts = from shirt in shirts
            //    where options.Sizes.Contains(shirt.Size)
            //    group shirt by shirt.Size
            //    into sizeGroup
            //    select new SizeCount()
            //    {
            //        Size = sizeGroup.Key,
            //        Count = sizeGroup.Count()
            //    };
           

            // TODO: search logic goes here.

            if (options != null)
            {
                if (options.Sizes.Any() || options.Colors.Any())
                {
                    var shirts = _shirts.Where(shirt => options.Colors.Contains(shirt.Color) || options.Sizes.Contains(shirt.Size)).ToList();

                    return new SearchResults
                    {
                        Shirts = shirts,

                        SizeCounts = Size.All.Select(size => new SizeCount
                        {
                            Size = size,
                            Count = shirts.Count<Shirt>(shirt => shirt.Size == size)
                        }).ToList(),

                        ColorCounts = Color.All.Select(color => new ColorCount
                        {
                            Color = color,
                            Count = shirts.Count<Shirt>(shirt => shirt.Color == color)
                        }).ToList()
                    };
                }
            }
            return new SearchResults();
        }
    }
}