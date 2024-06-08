﻿using MaterialSkin.Controls;
using MaterialSkin;
using System;
using System.Net.Http;
using System.Net;
using Modelos;
using Datos;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmInicio : MaterialForm
    {

        CookieContainer cookieContainer;
        HttpClient cliente;

        public frmInicio()
        {
            InitializeComponent();


            //Aplicar el diseño de material desing al formulario
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green800, Primary.Green900, Primary.Green500, Accent.Green700, TextShade.WHITE);
        }

        public frmInicio(HttpClient cliente, CookieContainer cookieContainer) : this()
        {
            try
            {
                this.cliente = cliente;
                this.cookieContainer = cookieContainer;
                InitializeAsync();
            }
            catch
            {
            }
        }

        private async void InitializeAsync()
        {
            try
            {
                if (this.cliente != null && this.cookieContainer != null)
                {
                    AlumnoAcademico alumnoAcademico = await new DAOAlumno().getAlumnoAcademico(cliente, cookieContainer);
                    lblNombreAlumno.Text = alumnoAcademico.nombre;
                    lblNoControl.Text = alumnoAcademico.matricula;
                    lblFechaHora.Text = alumnoAcademico.fechaReins;
                    lblEspecialidad.Text = alumnoAcademico.especialidad;
                    lblCreditosReunidos.Text = alumnoAcademico.cdtosAcumulados.ToString();
                    lblCreditosActuales.Text = alumnoAcademico.cdtosActuales.ToString();
                    lblSemestreActual.Text = alumnoAcademico.semActual.ToString();
                    lblCarrera.Text = alumnoAcademico.carrera;
                }
            }
            catch (Exception ex)
            {
               
            }
        }

        private void TabsControlDrawer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tab = TabsControlDrawer.SelectedIndex;

            MessageBox.Show(tab.ToString());
        }
    }
}
