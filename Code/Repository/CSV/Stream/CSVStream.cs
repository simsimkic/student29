/***********************************************************************
 * Module:  CSVStream.cs
 * Purpose: Definition of the Class Repository.CSVStream
 ***********************************************************************/

using Repository.Csv.Converter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Repository.Csv.Stream
{
   public class CSVStream<E> : ICSVStream<E> where E : class
    {
        private readonly string _path;
        private readonly ICSVConverter<E> _converter;

        public CSVStream(string path, ICSVConverter<E> converter)
        {
            _path = path;
            _converter = converter;
        }

        public void AppendToFile(E entity)
         => File.AppendAllText(_path,
               _converter.ConvertEntityToCSVFormat(entity) + Environment.NewLine);

        public List<E> ReadAll()
            => File.ReadAllLines(_path)
                    .Select(_converter.ConvertCSVFormatToEntity)
                    .ToList();

        public void SaveAll(List<E> entities)
            => WriteAllLinesToFile(
                     entities
                     .Select(_converter.ConvertEntityToCSVFormat)
                     .ToList());

        public void WriteAllLinesToFile(IEnumerable<string> content)
            => File.WriteAllLines(_path, content.ToArray());
    }
}