// See https://aka.ms/new-console-template for more information

/*
Console.WriteLine("Welcome to the Application!");
Console.Write("Enter your name: ");
string? name = Console.ReadLine();

Console.Write("What is your Age? ");
string? ageAsString = Console.ReadLine();
int age = 0;

try
{
    age = int.Parse(ageAsString);
}
catch (FormatException)
{
    Console.WriteLine("Enter a number for your age, jerk!");
    throw;
}

if (name == null)
{
    Console.WriteLine("Come on! Tell me your name!");
}
else
{
    Console.WriteLine($"Welcome to the application, {name}! Good to see you! You are {age} years old!");
}
*/

/*
* We will ask the user for their:
* Email Address
* The ID of the course they'd like to take.
* The ID of the offering of that course they'd like to take.
*
* We will return to them:
* (Happy Path): A message that says their are registered, and a registration ID, and the date of the course.
* (Error): A message that says they cannot enroll for the course, and reason.
*/

//Console.WriteLine("Register for a Course");

//Console.Write("Enter your email address: ");
//var email = Console.ReadLine();

//Console.Write("Enter the course ID: ");
//var courseId = Console.ReadLine();

//Console.Write("The Course offering ID: ");
//var courseOfferingId = Console.ReadLine();

//Console.WriteLine($"I see you are {email}, want to take {courseId} of {courseOfferingId}");

//// WTCYWYH - Write the code you wish you had

//CourseRegistrationManager courseRegistrationManager = new CourseRegistrationManager();

//CourseRegistrationRequest request = new CourseRegistrationRequest(email, courseId, courseOfferingId);

//CourseRegistrationResponse response
//    = courseRegistrationManager.RegisterForCourse(email, courseId, courseOfferingId);

//if (response.IsRegistered)
//{
//    Console.WriteLine("Congratulations! You have been registered!");
//    Console.WriteLine($"Your Registration Id is {response.Id}");
//    Console.WriteLine($"The course starts on {response.courseDate:d}");
//}
//else
//{
//    Console.WriteLine("Sorry you are not registered for the course");
//}

using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder();

builder.Services.AddScoped<CourseRegistrationManager>();

var app = builder.Build();

app.MapPost("/registrations", (
    [FromBody] CourseRegistrationRequest request, 
    [FromServices] CourseRegistrationManager manager) =>
{
    var response = manager.RegisterForCourse(request);
    if(response.IsRegistered)
    {
        return Results.Ok(response);
    } else
    {
        return Results.BadRequest(response);
    }
});


Console.WriteLine("Fixing to run your web application!");
app.Run();
Console.WriteLine("Done running your web application!");