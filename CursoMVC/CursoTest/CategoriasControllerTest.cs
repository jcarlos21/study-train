﻿using CursoAPI.Controllers;
using CursoMVC.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;  // Necessário para as Tasks.
using Xunit;

namespace CursoTest {

    public class CategoriasControllerTest {

        // Criando as variáveis
        private readonly Mock<DbSet<Categoria>> _mockSet;
        private readonly Mock<Contexto> _mockContext;
        private readonly Categoria _categoria;

        public CategoriasControllerTest() {  // 'ctor' e TAB cria automaticamente um construtor.

            // Inicializando as variáveis criadas
            _mockSet = new Mock<DbSet<Categoria>>();
            _mockContext = new Mock<Contexto>();
            _categoria = new Categoria { Id = 1, Descricao = "Teste Categoria" };

            _mockContext.Setup(m => m.Categorias).Returns(_mockSet.Object);
            _mockContext.Setup(m => m.Categorias.FindAsync(1))
                .ReturnsAsync(_categoria);

        }

        [Fact]

        public async Task Get_Categoria() {

            var service = new CategoriasController(_mockContext.Object);

            var testCategoria = await service.GetCategoria(1);

            _mockSet.Verify(m => m.FindAsync(1),
                Times.Once());
        }


    }
}
