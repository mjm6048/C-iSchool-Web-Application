using iSchoolWebApp.Models;
using iSchoolWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;

namespace iSchoolWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            /*
             * My steps
             * 1. Go get the data
             * - In order to do that, I need to spin up my data getting class.
             * - Send off the request and get it back
             * 2. Apply it to my Model.
             * 3. Send the model to view.
             */
            //load my getData class
            DataRetrieval dataRet = new DataRetrieval();
            var loadedAbout = await dataRet.GetData("about/");
            // What is it? A string! Need Json. Use Newtonsoft Json!
            var returnValue = JsonConvert.DeserializeObject<AboutRootModel>(loadedAbout);
            return View(returnValue);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Degrees()
        {
            //load the data...
            DataRetrieval dataRet = new DataRetrieval();
            //tell the instance to go get the data...
            var loadedDegrees = await dataRet.GetData("degrees/");
            //cast it to json and the objects that we want.
            var returnResults = JsonConvert.DeserializeObject<DegreesRootModel>(loadedDegrees);
            return View(returnResults);
        }

        public async Task<IActionResult> Minors()
        {
            //load the data...
            DataRetrieval dataRet = new DataRetrieval();
            //tell the instance to go get the data...
            var loadedMinors = await dataRet.GetData("minors/");
            //cast it to json and the objects that we want.
            var returnResults = JsonConvert.DeserializeObject<MinorsRootModel>(loadedMinors);
            return View(returnResults);
        }

        public async Task<IActionResult> Employment()
        {
            //load the data...
            DataRetrieval dataRet = new DataRetrieval();
            //tell the instance to go get the data...
            var loadedEmployment = await dataRet.GetData("employment/");
            //cast it to json and the objects that we want.
            var returnResults = JsonConvert.DeserializeObject<EmploymentRootModel>(loadedEmployment);
            return View(returnResults);
        }

        public async Task<IActionResult> People()
        {
            //load the data...
            DataRetrieval dataRet = new DataRetrieval();
            //tell the instance to go get the data...
            var loadedPeople = await dataRet.GetData("people/");
            //cast it to json and the objects that we want.
            var returnResults = JsonConvert.DeserializeObject<PeopleRootModel>(loadedPeople);
            return View(returnResults);
        }

        [HttpGet]
        [Route("Home/Course/{courseID}")]
        public async Task<IActionResult> Course(String courseID)
        {
            //load the data...
            DataRetrieval dataRet = new DataRetrieval();
            //tell the instance to go get the data...
            var loadedCourse = await dataRet.GetData("course/courseID="+courseID);
            //cast it to json and the objects that we want.
            var returnResults = JsonConvert.DeserializeObject<CourseRootModel>(loadedCourse);
            return View(returnResults);
        }
    }
}