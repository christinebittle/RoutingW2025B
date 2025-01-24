using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoutingW2025B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {

        /// <summary>
        /// A route example
        /// </summary>
        /// <returns>Routing 1</returns>
        /// <example>
        /// GET api/Route/Get1 -> Routing1
        /// </example>
        [HttpGet(template:"Get1")]
        public string Get1()
        {
            return "Routing 1";
        }

        /// <summary>
        /// A welcome greeting to a course code and section
        /// </summary>
        /// <returns>A welcome greeting based on the course code entered</returns>
        /// <param name="CourseCode">The course code to welcome</param>
        /// <param name="Section">The section to welcome</param>
        /// <param name="Semester">The semester to welcome</param>
        /// <example>
        /// GET api/Route/Welcome?CourseCode=5125&Section=B&Semester=Summer -> "Welcome to 5125 Section B Summer Semester"
        /// </example>
        /// <example>
        /// GET api/Route/Welcome?CourseCode=5126&Section=A&Semester=Winter -> "Welcome to 5126 Section A Winter Semester"
        /// </example>
        [HttpGet(template: "Welcome")]
        public string Welcome(string CourseCode, string Section, string Semester)
        {
            return $"Welcome to {CourseCode} Section {Section} {Semester} Semester";
        }





        /// <summary>
        /// Receives an animal and outputs a message saying that is the favorite animal
        /// </summary>
        /// <param name="Animal">The animal to receive</param>
        /// <returns>A message stating the animal is the favorite</returns>
        /// <example>
        /// GET: api/Route/Get3/{Animal} -> "Your favorite animal is {Animal}"
        /// </example>
        /// <example>
        /// GET: api/Route/Get3/Snake -> "Your favorite animal is Snake"
        /// </example>
        [HttpGet(template:"/api/Route/Get3/{Animal}")]
        public string Get3(string Animal)
        {
            return "Your favorite animal is "+Animal;
        }


        /// <summary>
        /// Receives the km and converts to miles
        /// </summary>
        /// <param name="km">the input distance in km</param>
        /// <returns>That same distance expressed in miles</returns>
        /// <example>
        /// POST : api/Route/KmToMiles
        /// HEADER: Content-Type: application/x-www-form-urlencoded
        /// POST DATA / FORM DATA / REQUEST BODY : km=1 
        /// -> 0.6215
        /// </example>
        /// <example>
        /// POST : api/Route/KmToMiles
        /// HEADER: Content-Type: application/x-www-form-urlencoded
        /// POST DATA / FORM DATA / REQUEST BODY : km=10 
        /// -> 6.215040397762586
        /// </example>
        [HttpPost(template:"KmToMiles")]
        [Consumes("application/x-www-form-urlencoded")]
        public double KmToMiles([FromForm]double km)
        {
            double miles = km * (1.0 / 1.609);
            return miles;
        }


        /// <summary>
        /// We are going to receive the length, width, and height of a prism in cm and output the volume of this prism in inches cubed
        /// </summary>
        /// <returns>
        /// The output volume in in^3
        /// </returns>
        /// <example>
        /// POST : api/Route/CmToInchesCubed
        /// Data: length_cm=1&height_cm=1&width_cm=1
        /// Headers: Content-Type: application/x-www-form-urlencoded
        /// -> the total volume of the prism is 0.0606in^3
        /// </example>
        /// /// <example>
        /// POST : api/Route/CmToInchesCubed
        /// Data: length_cm=100&height_cm=100&width_cm=100
        /// Headers: Content-Type: application/x-www-form-urlencoded
        /// -> The total volume is 61023.744094732254 in^3
        /// </example>
        [HttpPost(template:"CmToInCubed")]
        public string CmToInCubed([FromForm]double height_cm, [FromForm] double width_cm, [FromForm] double length_cm)
        {
            // the ratio to convert cm to in
            double cm_to_in = 1 / 2.54;
            

            double height_in = height_cm * cm_to_in;
            double width_in = width_cm * cm_to_in;
            double length_in = length_cm * cm_to_in;

            double volume_in_cubed = height_in * width_in * length_in;

            return $"The total volume is {volume_in_cubed} in^3";
        }


        /// <summary>
        /// Receives a snack as POST Data and outputs a message of what your favorite snack is
        /// </summary>
        /// <param name="Snack">Your favorite snack</param>
        /// <returns>A message highlighting your favorite snack</returns>
        /// <example>
        /// POST: localhost:xx/api/Route/Post1
        /// HEADER: Content-Type: application/json
        /// FORM DATA / REQUEST BODY: "Blueberries"
        /// -> "Your favorite snack is Blueberries"
        /// </example>
        /// /// <example>
        /// POST: localhost:xx/api/Route/Post1
        /// HEADER: Content-Type: application/json
        /// FORM DATA / REQUEST BODY: "Ice Cream"
        /// -> "Your favorite snack is Ice Cream"
        /// </example>
        [HttpPost(template:"Post1")]
        public string Post1([FromBody]string Snack)
        {
            return "Your favorite snack is "+Snack;
        }

    }
}
