export interface MtgList {
    has_more: boolean;
    data: Data;
    next_page?: string;
    total_cards: number;
}

export interface Data {
    id: string;
    name: string;
    rarity: string;
    uri: string;
    set_name: string;
    image_uris: Images;
}

export interface Images{
    normal: string;
    small: string;
    png: string;
}