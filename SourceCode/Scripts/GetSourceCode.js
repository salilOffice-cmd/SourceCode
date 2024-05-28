const puppeteer = require('puppeteer');

(async () => {
    const url = process.argv[2]; // Get the URL from command line arguments
    if (!url) {
        console.error('URL is required');
        process.exit(1);
    }

    const browser = await puppeteer.launch();
    const page = await browser.newPage();
    await page.goto(url, { waitUntil: 'networkidle2' });
    const content = await page.content();
    console.log(content);
    await browser.close();
})();
