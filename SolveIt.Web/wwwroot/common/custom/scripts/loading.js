export const Loading = {

    start: function (selector = 'body') {

        $(selector).waitMe({
            effect: 'roundBounce',
            text: 'لطفا صبر کنید ...',
            bg: 'rgba(255, 255, 255, 0.7)',
            color: '#000'
        });
    },

    stop: function (selector = 'body') {
        $(selector).waitMe('hide');
    }

};