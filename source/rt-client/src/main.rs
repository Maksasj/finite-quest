use reqwest;
use reqwest::header::*;
use serde::{Deserialize, Serialize};
use serde_json::*;

#[derive(Serialize, Deserialize, Debug)]
struct Realm {
    realm_name: String,
    realm_status: String,
    main_endpoint: String,
}

#[derive(Serialize, Deserialize, Debug)]
struct APIResponse {
    realms: Vec<Realm>,
}

#[tokio::main]
async fn main() {
    let url = format!(
        "https://maksasj.github.io/finite-quest/status.json"
    );

    let response = reqwest::get(url)
        .await
        .unwrap();

    match response.status() {
        reqwest::StatusCode::OK => {
            match response.json::<APIResponse>().await {
                Ok(parsed) => {
                    for r in parsed.realms.iter() {
                        println!("Realm: ");
                        println!("    {}", r.realm_name);
                        println!("    {}", r.realm_status);
                        println!("    {}", r.main_endpoint);
                    }
                }

                Err(_) => println!("Hm, the response didn't match the shape we expected."),
            };
        }
        reqwest::StatusCode::UNAUTHORIZED => {
            println!("Need to grab a new token");
        }
        other => {
            panic!("Uh oh! Something unexpected happened: {:?}", other);
        }
    };
}