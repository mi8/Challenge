export class MtgDetail {
    name: string;
    rarity: string;
    prices: Price;
    released_at: string;
    image_uris: Images;
}

export class Price {
    usd: string;
    eur: string;   
}

export class Images {
    normal: string;
    small: string;
    png: string;
}