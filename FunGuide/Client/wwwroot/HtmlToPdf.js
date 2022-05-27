export function generateAndDownloadPdf(htmlOrElement, filename) {
    const doc = new jspdf.jsPDF({
        orientation: 'p',
        unit: 'pt',
        format: 'a4'
    });
    doc.autoTable({
       html:"#listOfSportsmen"
    })
    return new Promise((resolve, reject) => {
        doc.html(htmlOrElement, {
            callback: doc => {
                doc.save(filename);
                resolve();
            }
        });
    });
}