        [HttpPost]
        public ActionResult GetData()
        {
            
            //Server side processing 
            int start = Convert.ToInt32(Request["start"]);
            int length = Convert.ToInt32(Request["length"]);
            string searchValue = (Request["search[value]"]);
            string sortColumnName = Request["columns[" + Request["order[0][column]"] + "][name]"];
            string sortDirection = Request["order[0][dir]"];

            List<Table here> List = new List<table here>();
            using (DataEntity db = new DataEntity())
            {
                List = db.blah.ToList();
                int totalRows = List.Count();
                
                //searching
                if (!string.IsNullOrEmpty(searchValue)) 
                {     
                //same columns as the data you entered in the data for ajax
                    List = List.
                        Where(x => x.property.ToString().Contains(searchValue.ToLower()) || x.property != null && x.property.ToString().Contains(searchValue.ToLower())
                        || x.property != null && x.property.ToString().Contains(searchValue.ToLower()) || x.property != null && x.property.ToLower().Contains(searchValue.ToLower())
                        || x.property != null && x.property.ToLower().Contains(searchValue.ToLower()) || x.property != null && x.property.ToLower().Contains(searchValue.ToLower())
                        || x.property != null && x.property.ToString().Contains(searchValue.ToLower())).ToList();
                }
                int totalRowsAfterFiltering = List.Count();
                
                //sorting
                List = List.OrderBy(sortColumnName + " " + sortDirection).ToList();

                //paging
                List = List.Skip(start).Take(length).ToList();

            return Json(new { data = List, draw = Request["draw"], recordsTotal = totalRows, recordsFiltered = totalRowsAfterFiltering }, JsonRequestBehavior.AllowGet);
            }


        }
