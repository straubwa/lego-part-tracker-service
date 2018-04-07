# lego-part-tracker-service

This is the back end RESTful service that helps keep track of finding Lego pieces needed to create a set that you own.  This service leverages data from http://rebrickable.com - a great site for all things Lego.

## getting started

* create account on rebrickable.com
* get shared key and add to secrets.json file in the following format.  This is found by right clicking on the project and selecting "Manage User Secrets"
{
  "rebrickable": {
    "key": "<key>"
  }
}
* first time you will need to create the back end sql database.  righ now this can be created with some temporary data by calling "../api/setupdatabase"
