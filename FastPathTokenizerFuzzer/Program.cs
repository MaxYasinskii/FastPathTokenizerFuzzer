using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing.Matching;
using SharpFuzz;

namespace FastPathTokenizerFuzzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Fuzzer.Run(stream =>
            {
                using (var test = new StreamReader(stream))
                {
                    string path = test.ReadLine();
                    PathSegment[] segments = new PathSegment[256];

                    FastPathTokenizer.Tokenize(path, segments);
                }
            });
        }
    }
}