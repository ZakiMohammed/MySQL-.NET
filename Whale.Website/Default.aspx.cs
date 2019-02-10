using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Whale.Website.AppCode;
using System.Data.Entity;
using MySql.Data.Entity;
using Whale.Model;
using Whale.Repository;

namespace Whale.Website
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var dataAccess = new DataAccess();
            //var posts = dataAccess.ExecuteTable("SELECT * FROM post ORDER BY create_at DESC");

            //var postContext = new PostContext();
            //var posts = postContext.Posts.ToList();

            var repo = new ApplicationRepository();

            gvPost.DataSource = repo.GetPostAll();
            gvPost.DataBind();
        }
    }
}