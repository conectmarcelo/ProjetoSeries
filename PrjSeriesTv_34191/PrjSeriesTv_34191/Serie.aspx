<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Serie.aspx.cs" Inherits="PrjSeriesTv_34191.Serie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	
	<link rel="stylesheet" type="text/css" href="css/estiloSerie.css">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="areaConteudo">
			<div class="conteudoSerie azul">
				
				
				<div class="fl capa">
					<figure>
						
                        <asp:Literal ID="litFotoSerie" runat="server"></asp:Literal>

					</figure>
				</div>
				
				<div class="fl idSerie">
					<span class="tituloSerie">
                        <asp:Literal ID="litNome" runat="server"></asp:Literal></span><br>
					<div class="dadosBase">
						<p>Título Original:<asp:Literal ID="litNomeOriginal" runat="server"></asp:Literal></p>
						<p>Ano de Estréia: <asp:Literal ID="litAno" runat="server"></asp:Literal></p>
						<asp:Literal ID="litEncerramento" runat="server"></asp:Literal>
						<p>Categorias: <asp:Literal ID="litCategorias" runat="server"></asp:Literal></p>
						<p>Temporadas: <asp:Literal ID="litTemporadas" runat="server"></asp:Literal> | Episódios: <asp:Literal ID="litQtdEpisodios" runat="server"></asp:Literal></p>
					</div>
				</div>

				<div class="cls"></div>

				<div class="divisoria">
					<a href="#sinopse"><div class="fl imPequeno itemMenuSerie">Sinopse</div></a>
					<a href="#temporadas"><div class="fl imGrande itemMenuSerie">Temporadas e episódios</div></a>
					<div class="cls"></div>
				</div>

			</div>

			<div class="areaDetalhes">
				<a name="sinopse">
					<h1>Sinopse</h1>
				</a>
                <p><asp:Literal ID="litSinopse" runat="server"></asp:Literal></p>

				<a name="temporadas">
					<h1>Temporadas e Episódios</h1>
				</a>

				<div class="areaTemporadas">
					Selecione: 
					<select class="comboSelecao">
                        <asp:Literal ID="litTemporadasDisponiveis" runat="server"></asp:Literal>
						<%--<option value="5">5º Temporada</option>
						<option value="4">4º Temporada</option>
						<option value="3">3º Temporada</option>
						<option value="2">2º Temporada</option>
						<option value="1" selected="selected">1º Temporada</option> --%>
					</select>

					<h2>1º Temporada</h2>
					<div class="areaEpisodios">
						<div class="fl ep epBorda">
							<p class="titulo">
								S01E01 - Piloto<br>
								<span class="subtitulo">Pilot - Exibição em: 01/05/2017 - 22min</span>
							</p>

							<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer orci ante, hendrerit a mi eget, fermentum tempor ante. Duis non molestie dui, non dignissim augue. Fusce at placerat dui, vel volutpat metus. Etiam non purus vitae sem lacinia placerat.</p>

							<p>Observação:<br>
							Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer orci ante, hendrerit a mi eget, fermentum tempor ante.</p> 
						</div>

						<div class="fl ep">
							<p class="titulo">
								S01E02 - 0-8-4<br>
								<span class="subtitulo">0-8-4 - Exibição em: 01/05/2017 - 22min</span>
							</p>
							<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer orci ante, hendrerit a mi eget, fermentum tempor ante. Duis non molestie dui, non dignissim augue. Fusce at placerat dui, vel volutpat metus. Etiam non purus vitae sem lacinia placerat.</p>

							<p>Observação:<br>
								Nenhuma observação encontrada!
							</p>
						</div>

						<div class="fl ep epBorda">
							<p class="titulo">
								S01E03 - The Asset<br>
								<span class="subtitulo">O Ativo - Exibição em: 01/05/2017 - 22min</span>
							</p>
							<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer orci ante, hendrerit a mi eget, fermentum tempor ante. Duis non molestie dui, non dignissim augue. Fusce at placerat dui, vel volutpat metus. Etiam non purus vitae sem lacinia placerat.</p>

							<p>Observação:<br>
								Nenhuma observação encontrada!
							</p>
						</div>

						<div class="fl ep">
							<p class="titulo">
								S01E04 - Eye Spy<br>
								<span class="subtitulo">Espião de Olho - Exibição em: 01/05/2017 - 22min</span>
							</p>
							<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer orci ante, hendrerit a mi eget, fermentum tempor ante. Duis non molestie dui, non dignissim augue. Fusce at placerat dui, vel volutpat metus. Etiam non purus vitae sem lacinia placerat.</p>

							<p>Observação:<br>
								Nenhuma observação encontrada!
							</p>
						</div>


						<div class="cls"></div>
					</div>
				</div>


			</div>

		</section>

	</main>



</asp:Content>
