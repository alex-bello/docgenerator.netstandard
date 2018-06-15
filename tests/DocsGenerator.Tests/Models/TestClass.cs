using System;

/// <summary>
/// Namespace that contains all of the models used to perform unit tests.
/// </summary>
namespace DocsGenerator.Tests.Models
{
    /// <summary>
    /// This is a sample class used to test the functionality of the documentation generator.
    /// </summary>
    public class TestClass : IEntity
    {
        /// <summary>
        /// The Id of the Test Class Entity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Name of the Test Class Entity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Method that writes "Hello" to the console.
        /// </summary>
        public void SayHello()
        {
            Console.WriteLine("Hello");
        }
    }
}