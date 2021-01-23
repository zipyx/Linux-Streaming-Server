/**
 * Swiper section video listing
 **/

var swiper = new Swiper('.swiper-container', {
    effect: 'coverflow',
    grabCursor: true,
    centeredSlides: true,
    spaceBetween: 40,
    loop: true,
    slidesPerView: 'auto',

    breakpoints: {
        640: {
            slidesPerView: 2
        },
        768: {
            slidesPerView: 3,
            slidesPerGroup: 3
        },
        1024: {
            slidesPerView: 5,
            slidesPerGroup: 5
        }
    },

    coverflowEffect: {
        rotate: 0,
        stretch: 0,
        depth: 0,
        modifier: 1,
        slideShadows: false,
    },

    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev'
    },

    pagination: {
        el: '.swiper-pagination',
        clickable: true,
    }
});