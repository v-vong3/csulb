// Importing Puppeteer package
const puppeteer = require('puppeteer')

// Sites to traverse
const sites = [
    { name: 'fakeSite', url: 'http://www.fake-example.org' },
    { name: 'google', url: 'https://www.google.com' },
    { name: 'yahoo', url: 'https://yahoo.com' },
    { name: 'bing', url: 'https://bing.com' },
]

/**
 * Navigate to a URL
 * @param {Page} page 
 * @param {String} url 
 * @param {Object} navOptions 
 */
const navigate = async (page, url, navOptions) => {
    // Create a Promise object
    return new Promise(async function (resolve, reject) {
        page.waitForSelector('body');

        // Actual navigation happens here
        await page.goto(url, navOptions)
            .then((response) => {
                // Making sure the navigation was successful
                if(response.status() !== 200) {
                    return reject(`Unsuccessful navigation to ${response.url()}`);
                }

                resolve(url);
            })
            .catch((err) => {
                return reject(err);
            });
    });
};

const pdfPath = (name) => { return `./pdfs/${name}.pdf` };

/**
 * Creates a PDF of page.  ONLY works if HEADLESS mode is true
 * @param {Page} page 
 * @param {String} name 
 */
const createPdf = async (page, name) => {
    return new Promise(async function (resolve, reject) {
        try {
            await page.emulateMedia('screen')
            await page.pdf({ path: pdfPath(name), printBackground: true })

            resolve(true);
        } catch (err) {
            return reject(err);
        }
    })
    
}

function timeout(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

/**
 * Automate a google search
 * @param {Page} page 
 */
const googleSearch = async (page) => {

    return new Promise(async function (resolve, reject) {
        await page.waitForSelector("body")

        await page.type("input[name='q']", "plants");
        await page.keyboard.press( 'Enter' );

        // Wait 10 seconds so the search results will finish loading
        // Without waiting, the DOM may not be ready yet.
        // Not ideal to have a static wait, but used here to show timing is crucial when crawling
        await timeout(10000); 

        await page.evaluate(() => {
            // You have access to the DOM directly here just like in the JavaScript Console
            // e.g. document.querySelector, document.body, etc.
        })

        resolve();

    })

}


// "Main" method
(async () => {
    const browser = await puppeteer.launch({
        headless: true,  // Show Chromium browser UI if False
        devtools: false,   // Open DevTools if true
        ignoreHTTPSErrors: true   // Ignores HTTPS errors if true
    });
    const navOptions = {  
        waitUntil: 'networkidle2', // No new two connections in last 500ms
        timeout: 0 // Unlimited time out
    };

    const page = await browser.newPage();

    // Add a custom page load event
    page.on('load', () => {
        console.log(`Loading ${page.url()}`)
    })

    // Iterate through every site/URL 
    for (site of sites) {
        await navigate(page, site.url, navOptions)
            .then(async () => {
                if(site.name === 'google') {
                    // Example of page interaction 
                    await googleSearch(page)
                }
            })
            .then(async () => {
                await createPdf(page, site.name)
            })
            .catch((err) => {
                // Swallows errors
                console.error(`Unable to navigate to ${site.url}`)
            })
    }

    // Clean up memory
    await page.close();
    await browser.close();

    console.log("Done")
})();




