window.onscroll = () => {

    if (window.scrollY > 0) {
        document.querySelector("#chat").classList.add('invert');
        document.querySelector("#chat img").src = "/imagens/icones/chat2.png";
    }
    else {
        document.querySelector("#chat").classList.remove('invert');
        document.querySelector("#chat img").src = "/imagens/icones/chat.png";
    }
};