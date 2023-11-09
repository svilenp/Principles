using Examples.KISS;

var before = new Before();
var after = new After();

var simpleObject = new SimpleModel()
{
    Name = "KISS",
    Id = 1001,
};

var complicatedResult = before.ProcessObjectProperties(simpleObject);

var kissResult = after.ProcessObjectProperties(simpleObject);

Console.WriteLine("Result from a complicated logic:");
Console.WriteLine(complicatedResult);

Console.WriteLine();

Console.WriteLine("K.I.S.S.:");
Console.WriteLine(kissResult);
