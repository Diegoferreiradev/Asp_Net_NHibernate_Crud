using FluentNHibernate_Crud.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FluentNHibernate_Crud.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno
        public ActionResult Index()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var alunos = session.Query<Aluno>().ToList();
                return View(alunos);
            }

        }

        // GET: Aluno/Details/5
        public ActionResult Details(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var aluno = session.Get<Aluno>(id);
                return View(aluno);
            }
        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aluno/Create
        [HttpPost]
        public ActionResult Create(Aluno aluno)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(aluno);
                        transaction.Commit();
                    }
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Aluno/Edit/5
        public ActionResult Edit(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var aluno = session.Get<Aluno>(id);
                return View(aluno);
            }
        }

        // POST: Aluno/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Aluno aluno)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var alterarAluno = session.Get<Aluno>(id);

                    alterarAluno.Nome = aluno.Nome;
                    alterarAluno.Email = aluno.Email;
                    alterarAluno.Curso = aluno.Curso;
                    alterarAluno.Sexo = aluno.Sexo;

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(alterarAluno);
                        transaction.Commit();
                    }
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Aluno/Delete/5
        public ActionResult Delete(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var aluno = session.Get<Aluno>(id);
                return View(aluno);
            }

                
        }

        // POST: Aluno/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Aluno aluno)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(aluno);
                        transaction.Commit();
                    }

                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
