Above and Beyond:

I was able to fully load every piece of data from 
the employment table and the coop education table into
two separate uses of the DataTable JQuery plugin.
It is paginated, searchable, and feels really responsive and clean.
- You should not have to install the DataTables since a CDN 
  handler is included in the project.
- Documentation: https://datatables.net/

I made sure to load every piece of data and I was
able to maneuver past different data structures from the API.
Everything relevant to the website is loaded and should be displayed
on the proper page.

Courses under Minors loads on demand and only a single course loads on click.
Courses is set up so that you can put in any courseID in the url and it will
redirect properly and load that course on demand. I do not pull all the courses
into an array and waste your data plan. (That's a lot of courses!)

Graduate and Undergraduate both are loaded on the same page under degrees.

All pieces of data are properly sectioned off within the code in
each file. Everything relating to a degree belongs in Degrees, etc.