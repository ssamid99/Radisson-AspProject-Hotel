﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Radisson.Application.AppCode.Services;
using Radisson.Domain.Models.DbContexts;
using Radisson.Domain.Models.Entities;
using Radisson.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Radisson.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly RadissonDbContext db;
        private readonly CryptoService crypto;
        private readonly EmailService emailService;

        public HomeController(RadissonDbContext db, CryptoService crypto, EmailService emailService)
        {
            this.db = db;
            this.crypto = crypto;
            this.emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(Subscribe model)
        {
            if (model.Email != null)
            {
                if (!ModelState.IsValid)
                {
                    string msg = ModelState.Values.First().Errors[0].ErrorMessage;

                    return Json(new
                    {
                        error = true,
                        message = msg
                    });
                }

                var entity = db.Subscribes.FirstOrDefault(s => s.Email.Equals(model.Email));

                if (entity != null && entity.IsApproved == true)
                {
                    return Json(new
                    {
                        error = true,
                        message = "Siz artıq abunəsiniz!"
                    });
                }

                if (entity == null)
                {
                    db.Subscribes.Add(model);
                    db.SaveChanges();
                }
                else if (entity != null)
                {
                    model.Id = entity.Id;
                }

                string token = $"{model.Id}-{model.Email}-{Guid.NewGuid()}";

                token = crypto.Encrypt(token, true);




                string message = $"Abunəliyinizi: <a href='{Request.Scheme}://{Request.Host}/approve-subscribe?token={token}'>link</a> vasitəsiylə təsdiqləyin";

                await emailService.SendMailAsync(model.Email, "Abunəlik emaili təsdiqləmə  ", message);

                return Json(new
                {
                    error = false,
                    message = "Doğrulama maili email adresinizə göndərildi!"
                });
            }
            else
            {
                return Json(new
                {
                    error = true,
                    message = "Boş buraxıla bilməz!"
                });
            }
        }

        [Route("/approve-subscribe")]
        public async Task<IActionResult> SubscribeApprove(string token)
        {
            //token = token.Decrypt(Program.key);
            token = crypto.Decrypt(token);

            Match match = Regex.Match(token, @"^(?<id>\d+)-(?<email>[^-]+)-(?<randomKey>.*)$");

            if (!match.Success)
            {
                //return "Invalid token!";
            }

            int id = Convert.ToInt32(match.Groups["id"].Value);
            string email = match.Groups["email"].Value;
            string randomKey = match.Groups["randomKey"].Value;

            var entity = db.Subscribes.FirstOrDefault(s => s.Id == id);

            if (entity == null)
            {
                //return "Not found!";
            }

            if (entity.IsApproved)
            {
                //return "Already approved!";
            }

            entity.IsApproved = true;
            entity.ApproveDate = DateTime.UtcNow.AddHours(4);
            db.SaveChanges();

            return View();

            //return $"Id: {id} | Email: {email} | RandomKey: {randomKey}";
        }
    }
}
