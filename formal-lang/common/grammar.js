const getClass = require('./classIdentifier');
const randomWord = require('./randomWordGenerator');


module.exports = class Grammar {
    data;

    constructor(data) {
        this.data = data;
    }


     /**
      * @param {NodeJS.ReadStream & {fd: 0}} stream
      * @returns {Promise<Grammar>}
      */
     static parseFromReadStream(stream) {
         return new Promise((resolve) => {
             const data = {};
             stream.addListener('data', d => {
                 let line = d.toString();

                 if (line === '\r\n') {
                     stream.pause();
                     resolve(new Grammar(data));
                     return;
                 }
                 const [source, target] = line
                     .replace(/[\r\n]+/gm, "")
                     .split("->", 2);

                 if (!data.hasOwnProperty(source)) {
                     data[source] = [];
                 }
                 data[source].push(target);
             });
         });
    }
    getClass() {
        return getClass(this.data);
    }

    generateRandomWord() {
         return randomWord(this.data);
    }
}
