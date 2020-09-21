using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Senai.EfCore.Utils
{
    public static class Upload
    {
     public static string Local(IFormFile file)
        {
            //Gero o nome do arquivo único
            //Pago a extensão do arquivo
            //Concateno o nome do arquivo com sua extensão
            //44736420643275275yyg03.png
            var nomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);

            //GetCurrentDirectory - Pega o caminho do diretório atual, aplicação esta
            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwRoot\upload\imagens", nomeArquivo);

            //Crio um objeto do tipo FileStream passando o caminho do arquivo
            //Passa a criar este arquivo
            using var streamImagem = new FileStream(caminhoArquivo, FileMode.Create);

            //Executa o comando de criação do arquivo no local informado
            file.CopyTo(streamImagem);

            //Aws,Azure,Cloud storage
            //var urlImagem = Chamada ao método salvar(nomearquivo)
            return "http://localhost:54946/upload/imagens/" + nomeArquivo;
        }
    }
    }
