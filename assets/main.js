document.addEventListener("DOMContentLoaded", (event) => {

    // remove unnecessary elements from README.md
    document.getElementById("tclibraryversions").remove(); 
    document.getElementById("twincat-versions-and-the-library-versions-it-ships-with").remove(); 
    document.querySelectorAll('main p').forEach(e => e.remove());

    // search
    const searchInput = document.getElementById('search');
    const rows = document.querySelectorAll('table tbody tr');

    if (searchInput && rows.length > 0) {
        searchInput.addEventListener('keyup', function () {
            let filter = this.value.toLowerCase();

            rows.forEach(row => {
                let cells = row.getElementsByTagName('td');
                let match = Array.from(cells).some(cell =>
                    cell.textContent.toLowerCase().includes(filter)
                );


                row.style.display = match ? '' : 'none';
            });
        });
    } else {
        console.warn("Search field or table rows not found.");
    }
});


