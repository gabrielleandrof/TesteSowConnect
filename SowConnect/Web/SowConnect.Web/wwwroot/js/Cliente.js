$(document).ready(function () {

    //var rootUri = "http://localhost:56672/api/"
    var rootUri = "https://localhost:44360/api/"

    var grid = $('#grid').grid({
        dataSource: rootUri + 'Clientes/',
        columns: [
            { field: 'nome', title: "Nome" },
            { field: 'tipoCliente', title: "Tipo de Conta" },
            { field: 'idBanco', title: 'Banco' }
        ]
    });

    $.getJSON(rootUri + "Bancos/", function (result) {
        var options = $("#selBancos");
        options.append($("<option />").val("-1").text("Selecione..."));
        $.each(result, function (i, item) {
            options.append($("<option />").val(item.id).text(item.nomeInstituicao));
        });
    });

    $("#btnSalvar").click(function () {
        var nome = $("#txtNome").val().trim();
        var saldo = $("#txtSaldo").val().trim().replace(",", ".");
        var tipoCliente = $("input[name='tipoConta']:checked").val();
        var banco = $("#selBancos").val();

        var cliente = {
            Nome: nome,
            IdBanco: banco,
            TipoCliente: tipoCliente
        }
        var contaBancaria = {
            IdBanco: banco,
            IdCliente: 0,
            Saldo: saldo
        }

        $.ajax({
            type: "POST",
            contentType: 'application/json',
            url: rootUri + "Clientes/",
            async: false,
            dataType: "json",
            data: JSON.stringify(cliente),
            success: function (r) {

                contaBancaria.idCliente = parseInt(r);
                $.ajax({
                    type: "POST",
                    contentType: 'application/json',
                    url: rootUri + "ContaBancaria/CriarContaBancaria/",
                    async: false,
                    dataType: "json",
                    data: JSON.stringify(contaBancaria),
                    success: function (res) {
                        $("#txtNome").val("");
                        $("#txtSaldo").val("");
                        $("#selBancos").val("-1");
                        grid.reload();
                    },
                    error: function (e) { alert("algo deu errado"); }
                });

            },
            error: function (e) { alert("algo deu errado"); }
        });
    });

});