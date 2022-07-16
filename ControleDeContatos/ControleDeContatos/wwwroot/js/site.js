

$('.close-alert').click(function () {
    $(".alert").hide('hide');
});



(function ($) {
    //    const gallery = {
    //     getPhotos: function (target) {
    //        let photos = [] 
    //        let children = $(target).children();

    //        children.each(function(i, e) {
    //          let photo = {
    //            indexImage: i + 1,
    //            urlImage: e.href,
    //            titleImage: e.title
    //          }
    //          photos.push(photo)
    //        })  

    //        this.getRenderGallery(photos)
    //      },
    //      init: function (target) {
    //        if(!target) {
    //           console.error('Falta passar o selector!')
    //           return
    //        }
    //        this.getPhotos(target)   
    //      }
    //    }

    //   gallery.init('#js-gallery')


    let children = $('#js-gallery').children()

    const galleryContainer = $('.gallery-container');
    const galleryNavigationNext = $('.next')
    const galleryNavigationPrev = $('.prev')


    galleryNavigationNext.click(function (e) {
        e.preventDefault()
        console.log('proximo clicado..')
    })

    galleryNavigationPrev.click(function (e) {
        e.preventDefault()
        console.log('anterior clicado..')
    })

    //Esconde a galeria   
    galleryContainer.click(function (e) {
        if (e.target.id == "gallery-container" ||
            e.target.id == "gallery-button-close") {
            $('.gallery-container').removeClass('-show')
        }
    })

    //  Mostra a galeria e imagem clicada 
    children.each(function (i, e) {
        $(e).click(function (event) {
            event.preventDefault()

            $('.gallery-container').addClass('-show')
            $('.gallery-photo').find('img').attr('src', e.href)

            console.log('element: ', e.href)
        })
    })

    function getRenderPhoto() {
        const galleryContent = $('.gallery-content')
        const galleryPhoto = $('div')
        const galleryImage = $('img');

        galleryImage.attr('alt', 'Imagem 001')
        galleryPhoto.addClass('gallery-photo')

        galleryPhoto.append(galleryImage)
        galleryContent.append(galleryPhoto)

    }

    function init(target) {
        if (!target) {
            console.error('Erro ao carregar o plugin')
            return
        }
        getRenderPhoto()
    }
    init('#js-gallery')
})(jQuery)
