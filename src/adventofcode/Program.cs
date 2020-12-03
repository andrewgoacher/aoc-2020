using System;
using System.Linq;
using System.Reflection;
using adventofcode.Challenge;

var challenges = Assembly.GetExecutingAssembly()
    .GetTypes()
    .Where(t => (typeof(IChallenge)).IsAssignableFrom(t) && !t.IsInterface)
    .OrderBy(n => n.Name)
    .Select(t => (IChallenge)Activator.CreateInstance(t));

foreach (var challenge in challenges)
{
    challenge.Run();
}