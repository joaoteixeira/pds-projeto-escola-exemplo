﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ProjetoEscola.Database;
using ProjetoEscola.Helpers;

namespace ProjetoEscola.Models
{
    internal class EscolaDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Escola escola)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT INTO escola VALUES " +
                "(null, @nome, @razao, @cnpj, @inscricao, @tipo, @data_cricao, @resp, @resp_tel, " +
                "@email, @telefone, @rua, @numero, @bairro, @complemento, @cep, @cidade, @estado);";

                comando.Parameters.AddWithValue("@nome", escola.NomeFantasia);
                comando.Parameters.AddWithValue("@razao", escola.RazaoSocial);
                comando.Parameters.AddWithValue("@cnpj", escola.Cnpj);
                comando.Parameters.AddWithValue("@inscricao", escola.InscEstadual);
                comando.Parameters.AddWithValue("@tipo", escola.Tipo);
                comando.Parameters.AddWithValue("@data_cricao", escola.DataCriacao?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@resp", escola.Responsavel);
                comando.Parameters.AddWithValue("@resp_tel", escola.ResponsavelTelefone);
                comando.Parameters.AddWithValue("@email", escola.Email);
                comando.Parameters.AddWithValue("@telefone", escola.Telefone);
                comando.Parameters.AddWithValue("@rua", escola.Rua);
                comando.Parameters.AddWithValue("@numero", escola.Numero);
                comando.Parameters.AddWithValue("@bairro", escola.Bairro);
                comando.Parameters.AddWithValue("@complemento", escola.Complemento);
                comando.Parameters.AddWithValue("@cep", escola.CEP);
                comando.Parameters.AddWithValue("@cidade", escola.Cidade);
                comando.Parameters.AddWithValue("@estado", escola.Estado);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Escola> List()
        {
            try
            {
                var lista = new List<Escola>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Escola";

                MySqlDataReader reader = comando.ExecuteReader();

                while(reader.Read())
                {
                    var escola = new Escola();

                    escola.Id = reader.GetInt32("id_esc");
                    escola.NomeFantasia = DAOHelper.GetString(reader, "nome_fantasia_esc");
                    escola.RazaoSocial = DAOHelper.GetString(reader, "razao_social_esc");
                    escola.Cnpj = DAOHelper.GetString(reader, "cnpj_esc");
                    escola.InscEstadual = DAOHelper.GetString(reader, "insc_estadual_esc");
                    escola.Tipo = DAOHelper.GetString(reader, "tipo_esc");
                    escola.Email = DAOHelper.GetString(reader, "email_esc");
                    escola.Telefone = DAOHelper.GetString(reader, "telefone_esc");
                    escola.Responsavel = DAOHelper.GetString(reader, "responsavel_esc");
                    escola.ResponsavelTelefone = DAOHelper.GetString(reader, "responsavel_telefone_esc");
                    escola.DataCriacao = DAOHelper.GetDateTime(reader, "data_criacao_esc");
                    
                    lista.Add(escola);
                }

                reader.Close();

                return lista;
                
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Escola escola)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "DELETE FROM Escola WHERE id_esc = @id";

                comando.Parameters.AddWithValue("@id", escola.Id);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações.");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Update(Escola escola)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "UPDATE Escola SET " +
                "nome_fantasia_esc = @nome, razao_social_esc = @razao, cnpj_esc = @cnpj, insc_estadual_esc = @inscricao," +
                " tipo_esc = @tipo, data_criacao_esc = @data_criacao, responsavel_esc = @resp " +
                "WHERE id_esc = @id";
                
                comando.Parameters.AddWithValue("@nome", escola.NomeFantasia);
                comando.Parameters.AddWithValue("@razao", escola.RazaoSocial);
                comando.Parameters.AddWithValue("@cnpj", escola.Cnpj);
                comando.Parameters.AddWithValue("@inscricao", escola.InscEstadual);
                comando.Parameters.AddWithValue("@tipo", escola.Tipo);
                comando.Parameters.AddWithValue("@data_criacao", escola.DataCriacao?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@resp", escola.Responsavel);

                comando.Parameters.AddWithValue("@id", escola.Id);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
