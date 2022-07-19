
//$(document).ready(function () {
//    $('#tabela-projeto').DataTable();
//});


$('#tabela-projeto').dataTable({
    "ordering": false,
    "language": {
        "lengthMenu": "Mostrar_MENU_linhas por página",
        "zeroRecords": "Nenhum registro encontrado",
        "info": "Mostrando _PAGE_ de _PAGES_",
        "infoEmpty": "Nenhum registro encontrado",
        "infoFiltered": "(Filtrando de _MAX_ Total registros)",
        "search": "Pesquisar",
        "paginate": {
            "first": "Primeiro",
            "last": "Ultimo",
            "next": "Seguinte",
            "previous": "Anterior"
        }
    }

});

        const inputImagem = document.querySelector('#ArquivoImagem');
    inputImagem.addEventListener('change', (e) => {
        var file = e.srcElement.files[0];
        var img = document.querySelector('#imgAtual');
        var reader = new FileReader();
        reader.onloadend = function () {
            img.src = reader.result;
        }
        reader.readAsDataURL(file);
    });
    





        const inputImagem = document.querySelector('#ArquivoImagem');
    inputImagem.addEventListener('change', (e) => {
        var file = e.srcElement.files[0];
        var img = document.querySelector('#imgAtual');
        var reader = new FileReader();
        reader.onloadend = function () {
            img.src = reader.result;
        }
        reader.readAsDataURL(file);
    });
    



    
        document.addEventListener("DOMContentLoaded", function (e) {
        var img = document.querySelector('#imgAtual');
        img.src = img.src + '?' + new Date().getTime();
    });
   
