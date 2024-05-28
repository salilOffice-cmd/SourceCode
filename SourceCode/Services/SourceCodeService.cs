using System.Diagnostics;
using System;

namespace SourceCode.Services
{
    public class SourceCodeService
    {
        public async Task<string> GetSourceCodeService(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return null;
            }

            url = "https://en.wikipedia.org/wiki/Chess";

            // Set up the process to run the Puppeteer script
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "node",
                    Arguments = $"GetSourceCode.js \"{url}\"", // Script and URL
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = @"C:\Users\sahil\source\repos\APIArchitectureProjects\SourceCode\SourceCode\Scripts" // Path to your Puppeteer script
                }
            };

            process.Start();

            // Read the output (HTML content)
            string output = await process.StandardOutput.ReadToEndAsync();
            //string errors = await process.StandardError.ReadToEndAsync();

            await process.WaitForExitAsync();

            //await Console.Out.WriteLineAsync(errors);
            // Return the output as the response
            return output;
        }

    }
}
