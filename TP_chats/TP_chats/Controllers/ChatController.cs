﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_Chat.Models;

namespace TP_chats.Controllers
{
    public class ChatController : Controller
    {
        private static List<Chat> meuteDeChats = Chat.GetMeuteDeChats();
       
        // GET: Chat
        public ActionResult Index()
        {
            return View(meuteDeChats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            var chat = meuteDeChats.FirstOrDefault(c => c.Id == id);

            if (chat != null)
            {
                return View(chat);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            var chat = meuteDeChats.FirstOrDefault(c => c.Id == id);

            if (chat != null)
            {
                return View(chat);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var chat = meuteDeChats.FirstOrDefault(c => c.Id == id);
                meuteDeChats.Remove(chat);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }


        // GET: Chat/Edit/5
        public ActionResult Edit(int id)
        {
            var chat = meuteDeChats.FirstOrDefault(c => c.Id == id);
            if (chat != null)
            {
                return View(chat);
            }
            return RedirectToAction("Index");
        }

        // POST: Chat/Edit/5
        [HttpPost]
        public ActionResult Edit(Chat chat)
        {
            try
            {
                var chatDb = meuteDeChats.FirstOrDefault(c => c.Id == chat.Id);
                chatDb.Nom = chat.Nom;
                chatDb.Age = chat.Age;
                chatDb.Couleur = chat.Couleur;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



    }
}
