using MVC_Music_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC_Music_Store.Controllers
{
    public class CustomersEmptyController : Controller
    {
        private ChinookEntities db = new ChinookEntities();

        // GET: CustomersEmpty
        public ActionResult Index(){ return View(db.Tracks.ToList()); }
        public ActionResult Search_artists()
        {
            IList<Artist> list = new List<Artist>();
            DateTime.TryParse(Request.QueryString["dateFrom"], out DateTime dateFrom);
            DateTime.TryParse(Request.QueryString["dateTo"], out DateTime dateTo);
            int.TryParse(Request.QueryString["top_number"], out int top_number);

            if (string.IsNullOrEmpty(Request.QueryString["top_number"]))
            {
                if (!(string.IsNullOrEmpty(Request.QueryString["dateFrom"])) && !(string.IsNullOrEmpty(Request.QueryString["dateTo"]))) //only dateFrom & dateTo
                {
                    list = (from i in db.Invoices join il in db.InvoiceLines on i.InvoiceId equals il.InvoiceId join t in db.Tracks on 
                           il.TrackId equals t.TrackId join al in db.Albums on t.AlbumId equals al.AlbumId join ar in db.Artists on 
                           al.ArtistId equals ar.ArtistId where i.InvoiceDate >= dateFrom && i.InvoiceDate <= dateTo group  ar by ar.ArtistId)
                           .OrderByDescending(b => b.Count()).Select(z => z.FirstOrDefault()).ToList();
                }
            }
            else if (string.IsNullOrEmpty(Request.QueryString["dateTo"]))
            {
                if(!(string.IsNullOrEmpty(Request.QueryString["dateFrom"]))) //only top_number & dateFrom
                { 
                    list = (from i in db.Invoices join il in db.InvoiceLines on i.InvoiceId equals il.InvoiceId join t in db.Tracks on 
                           il.TrackId equals t.TrackId join al in db.Albums on t.AlbumId equals al.AlbumId join ar in db.Artists on 
                           al.ArtistId equals ar.ArtistId where i.InvoiceDate >= dateFrom group ar by ar.ArtistId)
                           .OrderByDescending(b => b.Count()).Select(z => z.FirstOrDefault()).Take(top_number).ToList();
                }
            }
            else if (string.IsNullOrEmpty(Request.QueryString["dateFrom"])) //only top_number & dateTo
            {
                list = (from i in db.Invoices join il in db.InvoiceLines on i.InvoiceId equals il.InvoiceId join t in db.Tracks on 
                       il.TrackId equals t.TrackId join al in db.Albums on t.AlbumId equals al.AlbumId join ar in db.Artists on 
                       al.ArtistId equals ar.ArtistId where i.InvoiceDate <= dateTo group ar by ar.ArtistId)
                       .OrderByDescending(b => b.Count()).Select(z => z.FirstOrDefault()).Take(top_number).ToList();
            }
            else //top_number & dateFrom & dateTo
            {
                list = (from i in db.Invoices join il in db.InvoiceLines on i.InvoiceId equals il.InvoiceId join t in db.Tracks on 
                       il.TrackId equals t.TrackId join al in db.Albums on t.AlbumId equals al.AlbumId join ar in db.Artists on 
                       al.ArtistId equals ar.ArtistId where i.InvoiceDate >= dateFrom && i.InvoiceDate <= dateTo group ar by ar.ArtistId)
                       .OrderByDescending(b => b.Count()).Select(z => z.FirstOrDefault()).Take(top_number).ToList();
                
            }
            return View(list);

        }

        public ActionResult Search_tracks() {
            IList<Track> list = new List<Track>();
            DateTime.TryParse(Request.QueryString["dateFrom"], out DateTime dateFrom);
            DateTime.TryParse(Request.QueryString["dateTo"], out DateTime dateTo);
            int.TryParse(Request.QueryString["top_number"], out int top_number);

            if (string.IsNullOrEmpty(Request.QueryString["top_number"]))
            {
                if (!(string.IsNullOrEmpty(Request.QueryString["dateFrom"])) && !(string.IsNullOrEmpty(Request.QueryString["dateTo"]))) //only dateFrom & dateTo
                {
                    list = (from i in db.Invoices join il in db.InvoiceLines on i.InvoiceId equals il.InvoiceId join t in db.Tracks on
                            il.TrackId equals t.TrackId where i.InvoiceDate >= dateFrom && i.InvoiceDate <= dateTo group t by t.TrackId)
                           .OrderByDescending(b => b.Count()).Select(z => z.FirstOrDefault()).ToList();
                }
            }
            else if (string.IsNullOrEmpty(Request.QueryString["dateTo"]))
            {
                if (!(string.IsNullOrEmpty(Request.QueryString["dateFrom"]))) //only top_number & dateFrom
                {
                    list = (from i in db.Invoices join il in db.InvoiceLines on i.InvoiceId equals il.InvoiceId join t in db.Tracks on
                            il.TrackId equals t.TrackId where i.InvoiceDate >= dateFrom group t by t.TrackId)
                           .OrderByDescending(b => b.Count()).Select(z => z.FirstOrDefault()).Take(top_number).ToList();
                }
            }
            else if (string.IsNullOrEmpty(Request.QueryString["dateFrom"])) //only top_number & dateTo
            {
                list = (from i in db.Invoices join il in db.InvoiceLines on i.InvoiceId equals il.InvoiceId join t in db.Tracks on
                        il.TrackId equals t.TrackId where i.InvoiceDate <= dateTo group t by t.TrackId)
                       .OrderByDescending(b => b.Count()).Select(z => z.FirstOrDefault()).Take(top_number).ToList();
            }
            else //top_number & dateFrom & dateTo
            {
                list = (from i in db.Invoices join il in db.InvoiceLines on i.InvoiceId equals il.InvoiceId join t in db.Tracks on
                        il.TrackId equals t.TrackId where i.InvoiceDate >= dateFrom && i.InvoiceDate <= dateTo group t by t.TrackId)
                       .OrderByDescending(b => b.Count()).Select(z => z.FirstOrDefault()).Take(top_number).ToList();

            }
            return View(list);
        }

        public ActionResult Search_genres() {
            IList<Genre> list = new List<Genre>();
            DateTime.TryParse(Request.QueryString["dateFrom"], out DateTime dateFrom);
            DateTime.TryParse(Request.QueryString["dateTo"], out DateTime dateTo);
            int.TryParse(Request.QueryString["top_number"], out int top_number);

            if (string.IsNullOrEmpty(Request.QueryString["top_number"]))
            {
                if (!(string.IsNullOrEmpty(Request.QueryString["dateFrom"])) && !(string.IsNullOrEmpty(Request.QueryString["dateTo"]))) //only dateFrom & dateTo
                {
                    list = (from i in db.Invoices join il in db.InvoiceLines on i.InvoiceId equals il.InvoiceId join t in db.Tracks on 
                        il.TrackId equals t.TrackId join g in db.Genres on t.GenreId equals g.GenreId where i.InvoiceDate >= dateFrom && i.InvoiceDate <= dateTo
                           group g by g.GenreId).OrderByDescending(b => b.Count()).Select(z => z.FirstOrDefault()).ToList();
                }
            }
            else if (string.IsNullOrEmpty(Request.QueryString["dateTo"]))
            {
                if (!(string.IsNullOrEmpty(Request.QueryString["dateFrom"]))) //only top_number & dateFrom
                {
                    list = (from i in db.Invoices join il in db.InvoiceLines on i.InvoiceId equals il.InvoiceId join t in db.Tracks on
                        il.TrackId equals t.TrackId join g in db.Genres on t.GenreId equals g.GenreId where i.InvoiceDate >= dateFrom
                           group g by g.GenreId).OrderByDescending(b => b.Count()).Select(z => z.FirstOrDefault()).Take(top_number).ToList();
                }
            }
            else if (string.IsNullOrEmpty(Request.QueryString["dateFrom"])) //only top_number & dateTo
            {
                list = (from i in db.Invoices join il in db.InvoiceLines on i.InvoiceId equals il.InvoiceId join t in db.Tracks on
                    il.TrackId equals t.TrackId join g in db.Genres on t.GenreId equals g.GenreId where i.InvoiceDate <= dateTo group g by g.GenreId)
                       .OrderByDescending(b => b.Count()).Select(z => z.FirstOrDefault()).Take(top_number).ToList();
            }
            else //top_number & dateFrom & dateTo
            {
                list = (from i in db.Invoices join il in db.InvoiceLines on i.InvoiceId equals il.InvoiceId join t in db.Tracks on
                       il.TrackId equals t.TrackId join g in db.Genres on t.GenreId equals g.GenreId where i.InvoiceDate >= dateFrom && i.InvoiceDate <= dateTo
                       group g by g.GenreId).OrderByDescending(b => b.Count()).Select(z => z.FirstOrDefault()).Take(top_number).ToList();

            }
            return View(list);
        }

    }
}
                