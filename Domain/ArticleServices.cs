using MySql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Domain
{
    public class ArticleServices
    {
        public ArticleCollection GetArticle(string startIndex,string count)
        {
            ArticleCollection articles = new ArticleCollection();
            DataTable dt = new MySqlServices().AA(Convert.ToInt32(startIndex),Convert.ToInt32(count));
            for(int i = 0;i<dt.Rows.Count;i++)
            {
                Article article = new Article();
                article.Content = dt.Rows[i][0].ToString();
                articles.Articles.Add(article);
            }
            return articles;
        }
    }
}
